namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IEmailProvider
	{
		void Send(string email, string message);
	}
}