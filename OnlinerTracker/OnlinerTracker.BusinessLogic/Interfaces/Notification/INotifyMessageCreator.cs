using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Interfaces.Notification
{
	public interface INotifyMessageCreator
	{
		string Create(NotifyResult notifyResult);
	}
}