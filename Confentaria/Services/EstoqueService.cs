using Confentaria.Data;
using Confentaria.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

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

            if (itensVinculados.Count == 0)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = "Nenhum item vinculado encontrado. Vincule pelo menos um item para processar a nota.";
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
                    // Aplica conversão de unidades (valida e converte)
                    var resultadoConversao = AplicarConversao(
                        item.FornecedorProduto,
                        item.Quantidade
                    );

                    if (!resultadoConversao.Sucesso)
                    {
                        resultado.Sucesso = false;
                        resultado.Mensagem = resultadoConversao.Mensagem;
                        resultado.FornecedorProdutoIdSemConversao = resultadoConversao.FornecedorProdutoId;
                        return resultado;
                    }

                    AtualizarEstoque(
                        item.FornecedorProduto.Produto,
                        resultadoConversao.QuantidadeConvertida,
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
            resultado.ItensIgnorados = itensNaoVinculados;
            
            var mensagem = $"✓ Nota fiscal processada com sucesso!\n\n";
            
            if (atualizarEstoque)
            {
                mensagem += $"• {resultado.ItensProcessados} produto(s) com estoque atualizado\n";
            }
            else
            {
                mensagem += $"• {resultado.ItensProcessados} produto(s) processado(s) (sem atualização de estoque)\n";
            }
            
            if (itensNaoVinculados > 0)
            {
                mensagem += $"• {itensNaoVinculados} item(ns) ignorado(s) (não vinculados)";
            }
            
            resultado.Mensagem = mensagem;
            return resultado;
        }

        /// <summary>
        /// Aplica conversão de unidades se necessário.
        /// Verifica se as unidades do fornecedor e do produto são diferentes,
        /// e valida se existe fator de conversão definido.
        /// </summary>
        /// <param name="fornecedorProduto">Vínculo entre fornecedor e produto</param>
        /// <param name="quantidade">Quantidade original da nota fiscal</param>
        /// <returns>Resultado com sucesso/erro e quantidade convertida</returns>
        private ResultadoConversao AplicarConversao(FornecedorProduto fornecedorProduto, decimal quantidade)
        {
            var resultado = new ResultadoConversao();
            
            // Obtém as unidades (normaliza para comparação)
            var unidadeFornecedor = (fornecedorProduto.UnidadeMedidaFornecedor ?? "UN").Trim().ToUpper();
            var unidadeProduto = fornecedorProduto.Produto.UnidadeMedida.Trim().ToUpper();

            // Verifica se as unidades são diferentes
            if (unidadeFornecedor != unidadeProduto)
            {
                // Unidades diferentes: PRECISA de fator de conversão
                if (fornecedorProduto.FatorConversao == null || fornecedorProduto.FatorConversao == 0)
                {
                    // ERRO: Não há fator de conversão definido
                    resultado.Sucesso = false;
                    resultado.FornecedorProdutoId = fornecedorProduto.Id;
                    resultado.Mensagem = $"⚠️ ERRO DE CONVERSÃO\n\n" +
                        $"Produto: {fornecedorProduto.Produto.Nome}\n" +
                        $"Unidade na nota: {unidadeFornecedor}\n" +
                        $"Unidade do produto: {unidadeProduto}\n\n" +
                        $"As unidades são DIFERENTES mas não há fator de conversão definido!";
                    return resultado;
                }

                // Aplica o fator de conversão
                resultado.Sucesso = true;
                resultado.QuantidadeConvertida = quantidade * fornecedorProduto.FatorConversao.Value;
                return resultado;
            }
            else
            {
                // Unidades iguais: não precisa converter
                resultado.Sucesso = true;
                resultado.QuantidadeConvertida = quantidade;
                return resultado;
            }
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
        public int ItensIgnorados { get; set; }
        public int? FornecedorProdutoIdSemConversao { get; set; }
    }

    /// <summary>
    /// Resultado da operação de conversão de unidades
    /// </summary>
    public class ResultadoConversao
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public decimal QuantidadeConvertida { get; set; }
        public int FornecedorProdutoId { get; set; }
    }
}
