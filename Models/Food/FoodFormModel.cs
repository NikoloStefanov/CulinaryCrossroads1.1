using System.ComponentModel.DataAnnotations;
using CullinaryCrossroads1._1.Infrastructure.Data.Models;
using CullinaryCrossroads1._1.Infrastructure.DataConstans;

namespace CulinaryCrossroads1._1.Models.Food
{
    public class FoodFormModel
    {
        [Required]
        [StringLength(Constans.TitleMaxLength,MinimumLength =Constans.TitleMinLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(Constans.RecipeMaxLength, MinimumLength =Constans.RecipeMinLength)]
        public string Recipe { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public IEnumerable<FoodCategoryServiceModel> Categories { get; set; } = new List<FoodCategoryServiceModel>();
        public int AgentId { get; set; }
    }
}
