using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MvcPoznamkyContext : DbContext
    {
        public MvcPoznamkyContext(DbContextOptions<MvcPoznamkyContext> options) : base(options) { }
        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Poznamka> Poznamky { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Poznamka>()
                .HasOne(c => c.Autor)
                .WithMany(a => a.Poznamky);
        }
    }
} 