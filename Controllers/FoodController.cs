using CulinaryCrossroads1._1.Models.Food;
using CullinaryCrossroads1._1.Core.Contacts;
using CullinaryCrossroads1._1.Core.Services;
using CullinaryCrossroads1._1.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryCrossroads1._1.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {      
        private readonly IFoodService foodService;
        private readonly IAgentService agentService;
        public FoodController(IFoodService foodService, IAgentService agentService)
        {
            this.foodService = foodService;
            
            this.agentService = agentService;
        }


        [HttpGet]
        public async Task< IActionResult> All()
        {
           
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!await agentService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }
          
            return View(new FoodFormModel
            {
                Categories = await foodService.AllCategoriesAsync()
            }) ;
        }
        [HttpPost]
        public async Task<IActionResult> Add(FoodFormModel model)
        {
            if (!await agentService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }
           
            if (await foodService.CategoryExistAsync(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await foodService.AllCategoriesAsync();
                return View(model);
            }
            int agendId = await agentService.GetAgentIdAsync(User.Id());
            var foodId = await foodService.CreateAsync(model.Title, model.Recipe, model.ImageUrl, model.CategoryId, agendId);
            return RedirectToAction(nameof(Details), new {id = foodId } );
        }
        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
