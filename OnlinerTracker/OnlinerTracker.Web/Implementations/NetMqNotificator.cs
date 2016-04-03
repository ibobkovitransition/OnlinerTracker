using NetMQ;
using OnlinerTracker.Web.Infrastructure;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Implementations
{
	public class NetMqNotificator : INotificator
	{
		private readonly NetMqWebSocketsContext context;

		public NetMqNotificator(NetMqWebSocketsContext context)
		{
			this.context = context;
		}

		public void Notify(string connectionId, string message)
		{
			context.Send(connectionId, message);
		}
	}
}