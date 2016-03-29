using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyService : INotifyService
	{
		private readonly IEmailNotifyService notifyApproach;
		private readonly INotifyMessageCreator messageCreator;

		public NotifyService(IEmailNotifyService notifyApproach, INotifyMessageCreator messageCreator)
		{
			this.notifyApproach = notifyApproach;
			this.messageCreator = messageCreator;
		}

		public void Notify(IEnumerable<NotifyResult> results)
		{
			foreach (var notifyResult in results)
			{
				var email = notifyResult.UserInfo.Email;
				if (email != null)
				{
					notifyApproach.Send(
						messageCreator.Create(notifyResult),
						email);
				}
			}
		}
	}
}