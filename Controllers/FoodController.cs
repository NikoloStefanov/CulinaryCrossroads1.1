using CulinaryCrossroads1._1.Models.Food;
using CullinaryCrossroads1._1.Core.Contacts;
using CullinaryCrossroads1._1.Core.Services;
using CullinaryCrossroads1._1.Infrastructure;
using CullinaryCrossroads1._1.Infrastructure.Data.Models;
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
        public async Task<IActionResult> Mine()
        {
            IEnumerable<FoodServiceModel> allMyRecipes = null;
            var userId = User.Id();
            if (await agentService.ExistByIdAsync(userId))
            {
                var currentAgentId = await agentService.GetAgentIdAsync(userId);
                allMyRecipes = await foodService.AllRecipesByAgentIdAsync(currentAgentId);
            }
            else
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            
            }
            return View(allMyRecipes);
        }


        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllFoodsQueryModel query)
        {
           var queryResult = foodService.All(
               query.Category,
               query.SearchTerm,
               query.Sorting,
               query.CurrentPage,
               AllFoodsQueryModel.FoodPerPage);
            query.TotalFoodsCount = queryResult.TotalFoodsCount;
            query.Foods = queryResult.Foods;
            var foodCategories = await foodService.AllCategoriesNameAsync();
            query.Categories = foodCategories;

            return View(query);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!await agentService.ExistByIdAsync(User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
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
        public async Task<IActionResult> Details(int id)
        {
            if (await foodService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            var foodDetails = await foodService.FoodDetailsByIdAsync(id);
            return View(foodDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await foodService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (await foodService.HasAgentWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }
            var food = await foodService.FoodDetailsByIdAsync(id);
            var foodCategoryId = await foodService.GetFoodCategoryIdAsync(id);

            var foodModel = new FoodFormModel()
            {
                Title = food.Title,
                Recipe = food.Recipe,
                ImageUrl = food.ImageUrl,
                CategoryId = foodCategoryId,
                Categories = await foodService.AllCategoriesAsync(),
            };
            return View(foodModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, FoodFormModel model)
        {
            if (await foodService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (await foodService.HasAgentWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }
            if (await foodService.CategoryExistAsync(id) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await foodService.AllCategoriesAsync();
                return View(model);
            }
            await foodService.EditAsync(id, model.Title, model.Recipe, model.ImageUrl, model.CategoryId);
            return RedirectToAction(nameof(Details), new { id = id });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            if (await foodService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (await foodService.HasAgentWithIdAsync(id, this.User.Id()) == false)
            {
                return Unauthorized();
            }
            var food = await foodService.FoodDetailsByIdAsync(id);
            var model = new FoodDetailsViewModel()
            {
                Title = food.Title,
                Recipe = food.Recipe,
                ImageUrl = food.ImageUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(FoodDetailsViewModel model)
        {

            if (await foodService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }
            if (await foodService.HasAgentWithIdAsync(model.Id, this.User.Id()) == false)
            {
                return Unauthorized();
            }
           
            await foodService.DeleteAsync(model.Id);
            return RedirectToAction(nameof(Mine));
        }
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            if (await foodService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (!await agentService.ExistByIdAsync(User.Id()))
            {
                return Unauthorized();
            }
            if (await foodService.IsLikedByUserIdAsync(id,User.Id()))
            {
                return BadRequest();
            }
          await foodService.Like(id, User.Id());
            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> Unlike(int id)
        {
            return View();
        }
    }
}
