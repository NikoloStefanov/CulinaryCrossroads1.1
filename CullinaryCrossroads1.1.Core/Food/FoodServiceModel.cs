using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CullinaryCrossroads1._1.Core.Services
{
    public class FoodServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
       
       
    }
}
