using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Interfaces.Notification
{
	public interface INotifyService
	{
		void Notify(IEnumerable<NotifyResult> results);
	}
}