using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class Producao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReceitaId { get; set; }

        [Required]
        public DateTime DataProducao { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CustoTotal { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoVenda { get; set; } = 0;

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Relacionamentos
        [ForeignKey("ReceitaId")]
        public virtual Receita Receita { get; set; } = null!;

        public virtual ICollection<ProducaoItem> Itens { get; set; } = new List<ProducaoItem>();
        public virtual ICollection<ProducaoProdutoGerado> ProdutosGerados { get; set; } = new List<ProducaoProdutoGerado>();
        public virtual ICollection<ProducaoSobra> Sobras { get; set; } = new List<ProducaoSobra>();
    }
}

