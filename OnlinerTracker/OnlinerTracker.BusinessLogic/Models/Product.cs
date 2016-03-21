using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class Product
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		[JsonProperty("is_tracked")]
		public bool IsTracked { get; set; }

		[JsonProperty("is_added")]
		public bool IsAdded { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("html_url")]
		public string HtmlUrl { get; set; }

		[JsonProperty("prices")]
		public Price Price { get; set; }

		[JsonProperty("images")]
		public Image Image { get; set; }
	}
}
