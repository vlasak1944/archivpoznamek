using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Controllers;

public class PoznamkaController : Controller
{
    private readonly MvcPoznamkyContext _context;

    public PoznamkaController(MvcPoznamkyContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Pridat()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Pridat(string nadpis, string telo)
    {
        if (nadpis == null || nadpis.Trim().Length == 0)
            return Redirect("Pridat");
        if (telo == null || telo.Trim().Length == 0)
            return Redirect("Pridat");

        Uzivatel prihlaseny = _context.Uzivatele
            .Where(u => u.Jmeno == HttpContext.Session.GetString("Uzivatel"))
            .First();

        Poznamka novy = new Poznamka { Nadpis = nadpis, Telo = telo, Autor = prihlaseny };

        _context.Poznamky.Add(novy);
        _context.SaveChanges();

        return Redirect("/Poznamka/Detail/" + novy.Id);
    }
    
    public IActionResult Detail(int id)
    {
        Poznamka nacteny = _context.Poznamky
            .Where(c => c.Id == id)
            .First();

        return View(nacteny);
    }
    public IActionResult Vsechny()
    {
        Uzivatel prihlaseny = _context.Uzivatele
            .Where(u => u.Jmeno == HttpContext.Session.GetString("Uzivatel"))
            .First();

        List<Poznamka> poznamky = prihlaseny.Poznamky;

        return View(poznamky);
    }
}
