using OnlinerTracker.Web.Infrastructure.NetMq;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Implementations
{
	public class NetMqNotificator : INotificator
	{
		private readonly Context context;

		public NetMqNotificator(Context context)
		{
			this.context = context;
		}

		public void Notify(string connectionId, string message)
		{
			context.Send(connectionId, message);
		}
	}
}