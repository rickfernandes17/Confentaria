using Microsoft.EntityFrameworkCore;
using Confentaria.Models;

namespace Confentaria.Data
{
    public class ConfentariaDbContext : DbContext
    {
        public ConfentariaDbContext(DbContextOptions<ConfentariaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaItem> ReceitaItens { get; set; }
        public DbSet<ReceitaProdutoGerado> ReceitaProdutosGerados { get; set; }
        public DbSet<ReceitaSobra> ReceitaSobras { get; set; }
        public DbSet<Producao> Producoes { get; set; }
        public DbSet<ProducaoItem> ProducaoItens { get; set; }
        public DbSet<ProducaoProdutoGerado> ProducaoProdutosGerados { get; set; }
        public DbSet<ProducaoSobra> ProducaoSobras { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorProduto> FornecedorProdutos { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<NotaFiscalItem> NotaFiscalItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de índices
            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.Codigo)
                .IsUnique()
                .HasFilter("[Codigo] IS NOT NULL");

            modelBuilder.Entity<FornecedorProduto>()
                .HasIndex(fp => new { fp.FornecedorId, fp.ProdutoId })
                .IsUnique();

            // Configurações de relacionamentos
            modelBuilder.Entity<ReceitaItem>()
                .HasOne(ri => ri.Receita)
                .WithMany(r => r.Itens)
                .HasForeignKey(ri => ri.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReceitaItem>()
                .HasOne(ri => ri.Produto)
                .WithMany(p => p.ReceitaItens)
                .HasForeignKey(ri => ri.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReceitaProdutoGerado>()
                .HasOne(rpg => rpg.Receita)
                .WithMany(r => r.ProdutosGerados)
                .HasForeignKey(rpg => rpg.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReceitaProdutoGerado>()
                .HasOne(rpg => rpg.Produto)
                .WithMany(p => p.ReceitaProdutosGerados)
                .HasForeignKey(rpg => rpg.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReceitaSobra>()
                .HasOne(rs => rs.Receita)
                .WithMany(r => r.Sobras)
                .HasForeignKey(rs => rs.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReceitaSobra>()
                .HasOne(rs => rs.Produto)
                .WithMany(p => p.ReceitaSobras)
                .HasForeignKey(rs => rs.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producao>()
                .HasOne(p => p.Receita)
                .WithMany(r => r.Producoes)
                .HasForeignKey(p => p.ReceitaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProducaoItem>()
                .HasOne(pi => pi.Producao)
                .WithMany(p => p.Itens)
                .HasForeignKey(pi => pi.ProducaoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProducaoItem>()
                .HasOne(pi => pi.Produto)
                .WithMany(p => p.ProducaoItens)
                .HasForeignKey(pi => pi.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProducaoProdutoGerado>()
                .HasOne(ppg => ppg.Producao)
                .WithMany(p => p.ProdutosGerados)
                .HasForeignKey(ppg => ppg.ProducaoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProducaoProdutoGerado>()
                .HasOne(ppg => ppg.Produto)
                .WithMany(p => p.ProducaoProdutosGerados)
                .HasForeignKey(ppg => ppg.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProducaoSobra>()
                .HasOne(ps => ps.Producao)
                .WithMany(p => p.Sobras)
                .HasForeignKey(ps => ps.ProducaoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProducaoSobra>()
                .HasOne(ps => ps.Produto)
                .WithMany(p => p.ProducaoSobras)
                .HasForeignKey(ps => ps.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FornecedorProduto>()
                .HasOne(fp => fp.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(fp => fp.FornecedorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FornecedorProduto>()
                .HasOne(fp => fp.Produto)
                .WithMany(p => p.FornecedorProdutos)
                .HasForeignKey(fp => fp.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotaFiscal>()
                .HasOne(nf => nf.Fornecedor)
                .WithMany(f => f.NotasFiscais)
                .HasForeignKey(nf => nf.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotaFiscalItem>()
                .HasOne(nfi => nfi.NotaFiscal)
                .WithMany(nf => nf.Itens)
                .HasForeignKey(nfi => nfi.NotaFiscalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NotaFiscalItem>()
                .HasOne(nfi => nfi.FornecedorProduto)
                .WithMany(fp => fp.NotaFiscalItens)
                .HasForeignKey(nfi => nfi.FornecedorProdutoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

