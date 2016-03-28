using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models.Onliner
{
	public class Image
	{
		[JsonProperty("header")]
		public string Header { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }
	}
}
