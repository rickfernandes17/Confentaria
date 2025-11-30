using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public enum TipoProduto
    {
        Ingrediente = 1,
        MateriaPrimaPronta = 2,
        Sobra = 3
    }

    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Codigo { get; set; }

        [Required]
        public TipoProduto Tipo { get; set; }

        [StringLength(20)]
        public string UnidadeMedida { get; set; } = "kg"; // kg, g, un, litro, etc

        [Column(TypeName = "decimal(18,3)")]
        public decimal EstoqueAtual { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PrecoMedio { get; set; }

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }

        // Relacionamentos
        public virtual ICollection<ReceitaItem> ReceitaItens { get; set; } = new List<ReceitaItem>();
        public virtual ICollection<ReceitaProdutoGerado> ReceitaProdutosGerados { get; set; } = new List<ReceitaProdutoGerado>();
        public virtual ICollection<ReceitaSobra> ReceitaSobras { get; set; } = new List<ReceitaSobra>();
        public virtual ICollection<ProducaoItem> ProducaoItens { get; set; } = new List<ProducaoItem>();
        public virtual ICollection<ProducaoProdutoGerado> ProducaoProdutosGerados { get; set; } = new List<ProducaoProdutoGerado>();
        public virtual ICollection<ProducaoSobra> ProducaoSobras { get; set; } = new List<ProducaoSobra>();
        public virtual ICollection<FornecedorProduto> FornecedorProdutos { get; set; } = new List<FornecedorProduto>();
    }
}

