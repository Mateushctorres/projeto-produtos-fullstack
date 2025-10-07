using Microsoft.EntityFrameworkCore;
using ProdutoEntity = Produto.Domain.Entities.Produto;

namespace Produto.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoEntity> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntity>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}