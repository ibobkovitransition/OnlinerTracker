using System;
using OnlinerTracker.BusinessLogic.Models.Basis;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Models.Notification
{
	public class NotifyHistory : BaseModel
	{
		public int UserInfoId { get; set; }

		public UserInfo UserInfo { get; set; }

		public int ProductId { get; set; }

		public Product Product { get; set; }

		public bool Notifited { get; set; }

		public DateTime? NotifitedAt { get; set; }
	}
}