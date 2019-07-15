using System.Diagnostics;
using AspNetCoreMvcExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "PokerHand", new {area = ""});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
