using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models.Onliner
{
	public class Price
	{
		[JsonProperty("min")]
		public decimal Min { get; set; }

		[JsonProperty("max")]
		public decimal Max { get; set; }
	}
}
