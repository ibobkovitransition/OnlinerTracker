using System;
using OnlinerTracker.BusinessLogic.Models.Basis;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Models.Notification
{
	public class NotifyHistory : BaseModel
	{
		public TimeSpan SendOn { get; set; }

		public int UserInfoId { get; set; }

		public UserInfo UserInfo { get; set; }

		public bool Notifited { get; set; }
	}
}