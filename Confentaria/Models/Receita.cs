using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class Receita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CustoTotal { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoVendaSugerido { get; set; } = 0;

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }

        // Relacionamentos
        public virtual ICollection<ReceitaItem> Itens { get; set; } = new List<ReceitaItem>();
        public virtual ICollection<ReceitaProdutoGerado> ProdutosGerados { get; set; } = new List<ReceitaProdutoGerado>();
        public virtual ICollection<ReceitaSobra> Sobras { get; set; } = new List<ReceitaSobra>();
        public virtual ICollection<Producao> Producoes { get; set; } = new List<Producao>();
    }
}

