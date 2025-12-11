using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Confentaria.Services
{
    public class EstoqueService
    {
        private readonly ConfentariaDbContext _context;

        public EstoqueService(ConfentariaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza o estoque de um produto e calcula o novo preço médio ponderado
        /// </summary>
        public void AtualizarEstoque(Produto produto, decimal quantidade, decimal precoUnitario, int? notaFiscalId = null)
        {
            // Calcula novo preço médio ponderado
            var estoqueAnterior = produto.EstoqueAtual;
            var precoAnterior = produto.PrecoMedio ?? 0;
            
            var valorAnterior = estoqueAnterior * precoAnterior;
            var valorNovo = quantidade * precoUnitario;
            var estoqueNovo = estoqueAnterior + quantidade;
            
            var precoMedioNovo = estoqueNovo > 0 
                ? (valorAnterior + valorNovo) / estoqueNovo 
                : precoUnitario;

            // Atualiza produto
            produto.EstoqueAtual = estoqueNovo;
            produto.PrecoMedio = precoMedioNovo;
            produto.DataAtualizacao = DateTime.Now;

            // Registra movimentação
            var movimentacao = new MovimentacaoEstoque
            {
                ProdutoId = produto.Id,
                Tipo = TipoMovimentacao.Entrada,
                QuantidadeAnterior = estoqueAnterior,
                Quantidade = quantidade,
                QuantidadeNova = estoqueNovo,
                PrecoUnitario = precoUnitario,
                NotaFiscalId = notaFiscalId,
                Observacao = $"Entrada via Nota Fiscal. Preço médio: {precoAnterior:F2} → {precoMedioNovo:F2}",
                DataMovimentacao = DateTime.Now
            };

            _context.MovimentacoesEstoque.Add(movimentacao);
            _context.SaveChanges();
        }

        /// <summary>
        /// Processa uma nota fiscal completa, atualizando estoque de todos os itens vinculados
        /// </summary>
        public ResultadoProcessamento ProcessarNotaFiscal(NotaFiscal nota, bool atualizarEstoque = true)
        {
            var resultado = new ResultadoProcessamento();

            var itensVinculados = _context.NotaFiscalItens
                .Include(i => i.FornecedorProduto)
                    .ThenInclude(fp => fp!.Produto)
                .Where(i => i.NotaFiscalId == nota.Id && i.FornecedorProdutoId != null)
                .ToList();

            var itensNaoVinculados = _context.NotaFiscalItens
                .Where(i => i.NotaFiscalId == nota.Id && i.FornecedorProdutoId == null)
                .Count();

            if (itensNaoVinculados > 0)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Existem {itensNaoVinculados} itens não vinculados. Vincule todos os itens antes de processar.";
                return resultado;
            }

            if (nota.DataProcessamento != null)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Esta nota fiscal já foi processada anteriormente.";
                return resultado;
            }

            foreach (var item in itensVinculados)
            {
                if (atualizarEstoque && item.FornecedorProduto?.Produto != null)
                {
                    // Aplica fator de conversão se existir
                    var fatorConversao = item.FornecedorProduto.FatorConversao ?? 1;
                    var quantidadeConvertida = item.Quantidade * fatorConversao;

                    AtualizarEstoque(
                        item.FornecedorProduto.Produto,
                        quantidadeConvertida,
                        item.ValorUnitario,
                        nota.Id
                    );
                    resultado.ItensProcessados++;
                }
            }

            // Marca nota como processada
            nota.DataProcessamento = DateTime.Now;
            _context.SaveChanges();

            resultado.Sucesso = true;
            resultado.Mensagem = $"Nota fiscal processada com sucesso! {resultado.ItensProcessados} produtos atualizados.";
            return resultado;
        }

        /// <summary>
        /// Obtém o histórico de movimentações de um produto
        /// </summary>
        public List<MovimentacaoEstoque> ObterHistorico(int produtoId, int? limit = null)
        {
            var query = _context.MovimentacoesEstoque
                .Where(m => m.ProdutoId == produtoId)
                .OrderByDescending(m => m.DataMovimentacao);

            if (limit.HasValue)
                return query.Take(limit.Value).ToList();

            return query.ToList();
        }
    }

    public class ResultadoProcessamento
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public int ItensProcessados { get; set; }
    }
}
