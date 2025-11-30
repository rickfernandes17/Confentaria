using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class ProducaoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProducaoId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CustoUnitario { get; set; }

        // Relacionamentos
        [ForeignKey("ProducaoId")]
        public virtual Producao Producao { get; set; } = null!;

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; } = null!;
    }
}

