using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MvcPoznamkyContext : DbContext
    {
        public MvcPoznamkyContext(SqlServerDbContextOptions<MvcPoznamkyContext> options){ }

        public DbSet<Uzivatel> Uzivatele { get; set; }
    }
}
// 1:05:25