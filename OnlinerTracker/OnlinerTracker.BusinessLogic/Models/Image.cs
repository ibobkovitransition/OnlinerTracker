using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class Image
	{
		[JsonProperty("header")]
		public string Header { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }
	}
}
