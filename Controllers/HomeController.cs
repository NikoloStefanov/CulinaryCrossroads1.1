using System.Diagnostics;
using CulinaryCrossroads1._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryCrossroads1._1.Controllers
{
    public class HomeController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }
  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}