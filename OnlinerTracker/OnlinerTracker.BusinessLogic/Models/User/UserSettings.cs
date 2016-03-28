using System;
using Newtonsoft.Json;
using OnlinerTracker.BusinessLogic.Models.Basis;

namespace OnlinerTracker.BusinessLogic.Models.User
{
	public class UserSettings : BaseModel
	{
		[JsonProperty("prefered_time")]
		public TimeSpan PreferedTime { get; set; }
	}
}