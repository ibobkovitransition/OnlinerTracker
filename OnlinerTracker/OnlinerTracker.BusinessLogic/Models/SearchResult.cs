using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class SearchResult
	{
		public IEnumerable<Product> Products { get; set; }

		[JsonProperty("total")]
		public int TotalItems { get; set; }

		public Page	Page { get; set; }
	}
}
