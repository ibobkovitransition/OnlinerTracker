using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{

	public class UserInfo 
	{
		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		// т.к. данный класс - обретка над OAuth.UserInfo, то это поле не нужно отдавать пользователю т.к. палим id-ник
		[JsonIgnore]
		public string UserId { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("settings")]
		public UserSettings UserSettings { get; set; }
	}
}
