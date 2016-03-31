using Newtonsoft.Json;
using OnlinerTracker.BusinessLogic.Models.Basis;

namespace OnlinerTracker.BusinessLogic.Models.User
{
	public class UserInfo : BaseModel
	{
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
