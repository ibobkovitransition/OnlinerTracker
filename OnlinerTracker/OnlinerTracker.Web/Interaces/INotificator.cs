namespace OnlinerTracker.Web.Interaces
{
	public interface INotificator
	{
		void Notify(string connectionId, string message);
	}
}