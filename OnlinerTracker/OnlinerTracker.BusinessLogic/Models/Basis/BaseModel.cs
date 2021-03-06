﻿using System;
using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models.Basis
{
	public abstract class BaseModel
	{
		[JsonProperty("id")]
		public virtual int Id { get; set; }

		[JsonProperty("createdAt")]
		public virtual DateTime? CreatedAt { get; set; } 
	}
}