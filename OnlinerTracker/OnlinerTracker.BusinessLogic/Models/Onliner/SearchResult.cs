using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models.Onliner
{
	public class SearchResult
	{
		[JsonProperty("products")]
		public IEnumerable<Product> Products { get; set; }

		[JsonProperty("total")]
		public int TotalItems { get; set; }

		[JsonProperty("page")]
		public Page Page { get; set; }
	}
}
