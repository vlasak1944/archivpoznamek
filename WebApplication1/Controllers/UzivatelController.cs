using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;
namespace WebApplication1.Controllers
{
    public class UzivatelController : Controller
    {
        private readonly MvcPoznamkyContext _context;

        public UzivatelController(MvcPoznamkyContext context)
        {

            _context = context;
        }
        [HttpGet]
        public IActionResult Prihlasit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registrovat()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Registrovat(string jmeno, string heslo, string heslo_kontrola)
        {
            if (jmeno == null || jmeno.Trim().Length == 0)
                return Redirect("Registrovat");
            if (heslo == null || heslo.Trim().Length == 0)
                return Redirect("Registrovat");
            if (heslo != heslo_kontrola)
                return Redirect("Registrovat");
            Uzivatel totozny = _context.Uzivatele
                .Where(u => u.Jmeno == jmeno)
                .FirstOrDefault();


            if (totozny != null)
                return Redirect("Registrovat");
            string hash = BCrypt.Net.BCrypt.HashPassword(heslo);
            Uzivatel novyUzivatel = new Uzivatel { Jmeno = jmeno, Heslo = hash };

            _context.Uzivatele.Add(novyUzivatel);
            _context.SaveChanges();

            return Redirect("Prihlasit");
        }
        [HttpPost]
        public IActionResult Prihlasit(string jmeno, string heslo)
        {
            if (jmeno == null || heslo == null)
                return Redirect("Prihlasit");


            Uzivatel hledany = _context.Uzivatele
                 .FirstOrDefault(u => u.Jmeno == jmeno);
            if (hledany == null)
                return Redirect("Prihlasit");

            if (!BCrypt.Net.BCrypt.Verify(heslo, hledany.Heslo))
                return Redirect("Prihlasit");

            return Redirect("Profil");
        }

        public IActionResult Profil()
         {
           return View();
         }
    }
}
