using System.ComponentModel.DataAnnotations;
using CullinaryCrossroads1._1.Core.Services;
using CullinaryCrossroads1._1.Infrastructure;

namespace CulinaryCrossroads1._1.Models.Food
{
    public class AllFoodsQueryModel
    {
        public const int FoodPerPage = 3;
        public string Category { get; init; } = string.Empty;
        [Display(Name ="Search by text")]
        public string SearchTerm { get; init; } = string.Empty;
        public FoodSorting Sorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalFoodsCount { get; set; } = 1;
        public IEnumerable<string> Categories { get; set; } = null!;
        public IEnumerable<FoodServiceModel> Foods { get; set; } = new List<FoodServiceModel>();


    }
}
