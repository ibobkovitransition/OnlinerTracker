using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{

	public class UserInfo 
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		// не отдаем клиенту id его соц сети - она тащится из кук
		[JsonIgnore]
		public string UserId { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("settings")]
		public UserSettings UserSettings { get; set; }
	}
}
