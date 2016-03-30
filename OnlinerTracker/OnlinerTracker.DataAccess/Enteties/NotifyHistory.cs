using System;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class NotifyHistory : BaseEntity
	{
		public TimeSpan SendOn { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public bool Notifited { get; set; }
	}
}