using GerenciadorDeEstufas.Estufa;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEstufasAPI.Context
{
    public class GerenciadorContext : DbContext
    {
        public GerenciadorContext(DbContextOptions<GerenciadorContext> opts) : base(opts)
        {
        }

        public DbSet<Estufa>? Estufas { get; set; }
        public DbSet<Amostra>? Amostras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amostra>()
                .HasIndex(i => i.IdAmostra)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
