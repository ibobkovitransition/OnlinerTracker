﻿using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class Page
	{
		[JsonProperty("current")]
		public int Current { get; set; }

		[JsonProperty("last")]
		public int PagesLeft { get; set; }

		[JsonProperty("limit")]
		public int PageSize { get; set; }
	}
}
