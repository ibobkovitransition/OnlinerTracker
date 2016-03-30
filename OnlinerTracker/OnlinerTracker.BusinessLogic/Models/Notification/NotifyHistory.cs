using System;
using OnlinerTracker.BusinessLogic.Models.Basis;

namespace OnlinerTracker.BusinessLogic.Models.Notification
{
	public class NotifyHistory : BaseModel
	{
		public TimeSpan SendOn { get; set; }

		public int UserId { get; set; }

		public DataAccess.Enteties.User User { get; set; }

		public bool Notifited { get; set; }
	}
}