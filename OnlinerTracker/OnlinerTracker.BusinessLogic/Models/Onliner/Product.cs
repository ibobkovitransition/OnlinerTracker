using Newtonsoft.Json;
using OnlinerTracker.BusinessLogic.Models.Basis;

namespace OnlinerTracker.BusinessLogic.Models.Onliner
{
	public class Product : BaseModel
	{
		[JsonProperty("full_name")]
		public string FullName { get; set; }

		[JsonProperty("is_tracked")]
		public bool IsTracked { get; set; }

		[JsonProperty("is_added")]
		public bool IsAdded { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("prices")]
		public Price Price { get; set; }

		[JsonProperty("images")]
		public Image Image { get; set; }

		[JsonProperty("increase")]
		public bool Increase { get; set; }

		[JsonProperty("decrease")]
		public bool Decrease { get; set; }
	}
}
