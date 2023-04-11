using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MvcPoznamkyContext : DbContext
    {
        public MvcPoznamkyContext(SqlServerDbContextOptions<MvcPoznamkyContext> options) : base(options) { }

        public DbSet<Uzivatel> Uzivatele { get; set; };
    }
}
