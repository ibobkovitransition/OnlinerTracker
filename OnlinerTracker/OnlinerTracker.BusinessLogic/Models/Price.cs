using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class Price
	{
		[JsonProperty("min")]
		public int Min { get; set; }

		[JsonProperty("max")]
		public int Max { get; set; }
	}
}
