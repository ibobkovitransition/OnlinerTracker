using Microsoft.AspNet.SignalR;

namespace OnlinerTracker.Web.Infrastructure
{
	// если биндится на производный, то не будет работать
	public class SignalrContext : PersistentConnection
	{
	}
}