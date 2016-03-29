namespace OnlinerTracker.BusinessLogic.Interfaces.Notification
{
	public interface IEmailNotifyService
	{
		void Send(string message, string email);
	}
}