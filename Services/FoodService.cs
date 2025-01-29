using CulinaryCrossroads1._1.Interface.Data;
using CulinaryCrossroads1._1.Models.Food;
using CullinaryCrossroads1._1.Core.Contacts;
using CullinaryCrossroads1._1.Core.Enumeration;
using CullinaryCrossroads1._1.Core.Models.Agent;
using CullinaryCrossroads1._1.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CullinaryCrossroads1._1.Core.Services
{
    public class FoodService : IFoodService
    {
        private readonly ApplicationDbContext data;
        public FoodService(ApplicationDbContext _data)
        {
           data = _data;
        }

        public async Task<FoodQueryServiceModel> AllAsync(string category = null, string searchTerm = null,
            FoodSorting sorting = FoodSorting.Newest, int currentPage = 1, int foodPerPage = 1)
        {
            var foodQuery = data.Foods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(category))
            {
                foodQuery = data.Foods.Where(c => c.Category.Name == category);
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                foodQuery = foodQuery
                    .Where(f => f.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    f.Recipe.ToLower().Contains(searchTerm.ToLower()));
            }
            foodQuery = sorting switch
            {
                FoodSorting.Newest => foodQuery.OrderByDescending(f => f.Id),
                FoodSorting.Oldest => foodQuery.OrderBy(f=>f.Id)
            };
            var foods = await foodQuery.Skip((currentPage - 1) * foodPerPage)
                .Take(foodPerPage)
                .Select(f => new FoodServiceModel()
                {
                    Id = f.Id,
                    Title = f.Title,
                    Recipe = f.Recipe,
                    ImageUrl = f.ImageURL,
                   
                })
                .ToListAsync() ;
            int totalFoods = await foodQuery.CountAsync();
            return new FoodQueryServiceModel()
            {
                TotalFoodsCount = totalFoods,
                Foods = foods

            };
        }

        public async Task<IEnumerable<FoodCategoryServiceModel>> AllCategoriesAsync()
        {
           return await data.Categories.Select(c => new FoodCategoryServiceModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
            
        }

        public async Task<IEnumerable<string>> AllCategoriesNameAsync()
        {
            return await data.Categories.Select(c => c.Name).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<FoodServiceModel>> AllRecipesByAgentIdAsync(int agentId)
        {
            var recipes = await data.Foods.Where(r => r.AgentId == agentId).Select(r=> new FoodServiceModel() 
            {
                Id = r.Id,
                Title = r.Title,
                Recipe = r.Recipe,
                ImageUrl = r.ImageURL
            }).ToListAsync();
            return recipes;
        }

     

        public async Task<bool> CategoryExistAsync(int id)
        {
            return await data.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<int> CreateAsync(string title, string recipe, string imageURL, int categoryId, int agentId)
        {
            var food = new Food()
            {
                Title = title,
                Recipe = recipe,
                ImageURL = imageURL,
                CategoryId = categoryId,
                AgentId = agentId
                

            };
            await data.Foods.AddAsync(food);
            await data.SaveChangesAsync();
            return food.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var food =await data.Foods.FindAsync(id);
             data.Foods.Remove(food);
            await data.SaveChangesAsync();
        }

        public async Task EditAsync(int foodId, string title, string recipe, string imageUrl, int categoryId)
        {
            var food = await data.Foods.FindAsync(foodId);
            food.Title = title;
            food.Recipe = recipe;
            food.ImageURL = imageUrl;
            food.CategoryId = categoryId;
            await data.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await data.Foods.AnyAsync(f => f.Id == id);
        }

        public async Task<FoodDetailsServiceModel> FoodDetailsByIdAsync(int id)
        {
            return await data.Foods.Where(f => f.Id == id).Select(f => new FoodDetailsServiceModel()
            {
                Id = f.Id,
                Title = f.Title,
                Recipe = f.Recipe,
                ImageUrl = f.ImageURL,
              
                Category = f.Category.Name,
                Agent = new AgentServiceModel()
                {
                    Email = f.Agent.User.Email,
                    PhoneNumber = f.Agent.PhoneNumber
                }

            }).FirstOrDefaultAsync();
            
        }

        public async Task<int> GetFoodCategoryIdAsync(int foodId)
        {
            var food = await data.Foods.FindAsync(foodId);
            return food.CategoryId;
        }

        public async Task<bool> HasAgentWithIdAsync(int foodId, string currentUserId)
        {
            var food = await data.Foods.FindAsync(foodId);
            var agent = await data.Agents.FirstOrDefaultAsync(a => a.Id == food.AgentId);

            if ( agent == null)
            {
                return false;
            }
            if (agent.UserId != currentUserId)
            {
                return false;
            }
            return true;
        }

      

        
    }
}
