using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Infrastructure.Persistence
{
    public  class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null;
        public DbSet<Produto> Produtos { get; set; } = null;


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


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