using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class NotaFiscal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        [StringLength(50)]
        public string? Numero { get; set; }

        [StringLength(50)]
        public string? Serie { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        [StringLength(500)]
        public string? Url { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; } = 0;

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataProcessamento { get; set; }

        // Relacionamentos
        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; } = null!;

        public virtual ICollection<NotaFiscalItem> Itens { get; set; } = new List<NotaFiscalItem>();
    }
}

