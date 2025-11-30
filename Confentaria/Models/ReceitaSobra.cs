using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class ReceitaSobra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReceitaId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantidade { get; set; }

        // Relacionamentos
        [ForeignKey("ReceitaId")]
        public virtual Receita Receita { get; set; } = null!;

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; } = null!;
    }
}

