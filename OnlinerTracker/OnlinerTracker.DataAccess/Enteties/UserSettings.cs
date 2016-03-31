using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class UserSettings : BaseEntity
	{
		[Key, ForeignKey("User")]
		public override int Id { get; set; }

		public virtual User User { get; set; }

		public TimeSpan PreferedTime { get; set; }
	}
}
