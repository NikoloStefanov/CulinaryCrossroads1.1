using System.ComponentModel.DataAnnotations;
using CullinaryCrossroads1._1.Infrastructure.DataConstans;

namespace CulinaryCrossroads1._1.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(Constans.PhoneNumeberMaxLength)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
