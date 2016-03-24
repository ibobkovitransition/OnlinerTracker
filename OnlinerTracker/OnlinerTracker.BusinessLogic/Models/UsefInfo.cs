using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{

	public class UserInfo 
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonIgnore]
		public string SocialNetworkUserId { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("settings")]
		public UserSettings UserSettings { get; set; }
	}
}
