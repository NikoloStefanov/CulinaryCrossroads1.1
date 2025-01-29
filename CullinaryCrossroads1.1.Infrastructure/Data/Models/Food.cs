using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CullinaryCrossroads1._1.Infrastructure.DataConstans;
using Microsoft.AspNetCore.Identity;

namespace CullinaryCrossroads1._1.Infrastructure.Data.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Constans.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(Constans.RecipeMaxLength)]
        public string Recipe { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;        
        [Required]
        public int AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
        

    }
}
