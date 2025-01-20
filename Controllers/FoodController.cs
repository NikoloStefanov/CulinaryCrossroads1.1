using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryCrossroads1._1.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {       
        public IActionResult All()
        {
            return View();
        }
    }
}
