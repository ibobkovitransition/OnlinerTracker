using System;
using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class UserSettings
	{
		[JsonProperty("prefered_time")]
		public TimeSpan PreferedTime { get; set; }

		[JsonProperty("selected_currency")]
		public string SelectedCurrency { get; set; }
	}
}