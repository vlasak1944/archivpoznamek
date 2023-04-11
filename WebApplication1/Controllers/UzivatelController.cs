using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    public class UzivatelController : Controller
    {
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
                return RedirectToAction("Registrovat");
            if (heslo == null || heslo.Trim().Length == 0) 
                return RedirectToAction("Registrovat");
            if (heslo != heslo_kontrola) 
                return RedirectToAction("Registrovat");
            throw new Exception();

            }

    }
}
