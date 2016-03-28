using System;
using Newtonsoft.Json;

namespace OnlinerTracker.BusinessLogic.Models.Basis
{
	// сделал для удобства при работе с обертками производными от BaseEntity
	public abstract class BaseModel
	{
		[JsonProperty("id")]
		public virtual int Id { get; set; }

		[JsonProperty("createdOn")]
		public virtual DateTime CreatedOn { get; set; } 
	}
}