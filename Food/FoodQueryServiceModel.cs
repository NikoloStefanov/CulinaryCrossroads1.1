using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CullinaryCrossroads1._1.Core.Services
{
    public class FoodQueryServiceModel
    {
        public int TotalFoodsCount { get; set; }
        public IEnumerable<FoodServiceModel> Foods { get; set; } = new List<FoodServiceModel>();
    }
}
