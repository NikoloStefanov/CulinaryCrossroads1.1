using CullinaryCrossroads1._1.Core.Models.Agent;

namespace CullinaryCrossroads1._1.Core.Services
{
    public class FoodDetailsServiceModel : FoodServiceModel
	{
		public string Category { get; set; } = string.Empty;
		public AgentServiceModel Agent { get; set; } = null!;
	}
}
