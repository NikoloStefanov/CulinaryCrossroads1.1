using CulinaryCrossroads1._1.Models.Food;
using CullinaryCrossroads1._1.Core.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryCrossroads1._1.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {      
        private readonly IFoodService foodService;
        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
        }
        [HttpGet]
        public async Task< IActionResult> All()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new FoodFormModel
            {
                Categories = await foodService.AllCategoriesAsync()
            }) ;
        }
        [HttpPost]
        public async Task<IActionResult> Add(FoodFormModel model)
        {
            
            if (await foodService.CategoryExistAsync(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await foodService.AllCategoriesAsync();
                return View(model);
            }
            var foodId = await foodService.CreateAsync(model.Title, model.Recipe, model.ImageUrl, model.CategoryId, model.UserId);
            return RedirectToAction(nameof(Details), new {id = foodId } );
        }
        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
