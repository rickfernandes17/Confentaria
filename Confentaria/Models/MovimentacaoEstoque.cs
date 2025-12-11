using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2,
        Ajuste = 3
    }

    public class MovimentacaoEstoque
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public TipoMovimentacao Tipo { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal QuantidadeAnterior { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantidade { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal QuantidadeNova { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PrecoUnitario { get; set; }

        [StringLength(500)]
        public string? Observacao { get; set; }

        public int? NotaFiscalId { get; set; }

        [Required]
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;

        // Relacionamentos
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; } = null!;

        [ForeignKey("NotaFiscalId")]
        public virtual NotaFiscal? NotaFiscal { get; set; }
    }
}
