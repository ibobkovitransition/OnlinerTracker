using System;

namespace OnlinerTracker.DataAccess.Enteties.Basis
{
	public abstract class BaseEntity
	{
		public virtual int Id { get; set; }
		public virtual DateTime CreatedAt { get; set; }
	}
}
