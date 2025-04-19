using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Infrastructure.Persistence
{
    public  class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}