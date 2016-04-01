using Microsoft.AspNet.SignalR;
using OnlinerTracker.Web.Infrastructure;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Implementations
{
	public class SignalrNotificator : INotificator
	{
		public void Notify(string message)
		{
			var context = GlobalHost.ConnectionManager.GetConnectionContext<SignalrContext>();
			// TODO: научить уведомлять по id подключения
			context.Connection.Broadcast(message);
		}
	}
}