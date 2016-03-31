using System;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class NotifyHistory : BaseEntity
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int ProductId { get; set; }

		public Product Product { get; set; }

		public bool Notifited { get; set; }

		public DateTime? NotifitedAt { get; set; }
	}
}