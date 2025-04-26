using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Infrastructure.Persistence
{
    public  class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVendido> ProdutosVendidos { get; set; }


        /*mapeamento da propriedade DataNascimento do Cliente para
        que o PostgreSQL não reclame do timestamp with time zone*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeando DataNascimento como timestamp sem timezone
            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataNascimento)
                .HasColumnType("timestamp without time zone");

            base.OnModelCreating(modelBuilder);
        }

    }
}