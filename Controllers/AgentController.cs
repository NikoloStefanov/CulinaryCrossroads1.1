using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryCrossroads1._1.Controllers
{
    public class AgentController : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult Become()
        {
            return View();
        }
    }
}
