using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Confentaria.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [StringLength(20)]
        public string? CnpjCpf { get; set; }

        [StringLength(200)]
        public string? Endereco { get; set; }

        [StringLength(50)]
        public string? Telefone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }

        // Relacionamentos
        public virtual ICollection<FornecedorProduto> Produtos { get; set; } = new List<FornecedorProduto>();
        public virtual ICollection<NotaFiscal> NotasFiscais { get; set; } = new List<NotaFiscal>();
    }
}

