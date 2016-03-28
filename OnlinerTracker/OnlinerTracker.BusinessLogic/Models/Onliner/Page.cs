using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models.Onliner
{
	public class Page
	{
		[JsonProperty("current")]
		public int Current { get; set; }

		[JsonProperty("last")]
		public int PagesLeft { get; set; }
	}
}
