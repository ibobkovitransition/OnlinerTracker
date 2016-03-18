using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class Product
	{
		public string Name { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		public string Description { get; set; }

		[JsonProperty("html_url")]
		public string HtmlUrl { get; set; }

		[JsonProperty("prices")]
		public Price Price { get; set; }

		[JsonProperty("images")]
		public Image Image { get; set; }
	}
}
