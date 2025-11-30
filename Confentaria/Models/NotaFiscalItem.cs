using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class NotaFiscalItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NotaFiscalId { get; set; }

        public int? FornecedorProdutoId { get; set; } // Pode ser null se não foi associado ainda

        [StringLength(200)]
        public string? DescricaoOriginal { get; set; }

        [StringLength(50)]
        public string? CodigoOriginal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorUnitario { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; } = 0;

        [StringLength(20)]
        public string? UnidadeMedida { get; set; }

        [StringLength(200)]
        public string? Observacoes { get; set; }

        // Relacionamentos
        [ForeignKey("NotaFiscalId")]
        public virtual NotaFiscal NotaFiscal { get; set; } = null!;

        [ForeignKey("FornecedorProdutoId")]
        public virtual FornecedorProduto? FornecedorProduto { get; set; }
    }
}

