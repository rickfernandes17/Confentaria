using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class FornecedorProduto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [StringLength(50)]
        public string? CodigoFornecedor { get; set; }

        [StringLength(200)]
        public string? DescricaoFornecedor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PrecoUnitario { get; set; }

        [StringLength(20)]
        public string? UnidadeMedidaFornecedor { get; set; }

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }

        // Relacionamentos
        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; } = null!;

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; } = null!;

        public virtual ICollection<NotaFiscalItem> NotaFiscalItens { get; set; } = new List<NotaFiscalItem>();
    }
}

