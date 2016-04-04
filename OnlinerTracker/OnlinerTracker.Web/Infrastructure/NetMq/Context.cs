using System;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.WebSockets;
using Ninject;

namespace OnlinerTracker.Web.Infrastructure.NetMq
{
	public class Context : IStartable
	{
		private readonly NetMQContext context;
		private Poller poller;
		private WSRouter router;
		private WSPublisher publisher;

		private string routerConnectionString = "ws://localhost:991";
		private string publisherConnectionString = "ws://localhost:992";

		public Context(NetMQContext context)
		{
			this.context = context;
		}

		public void Start()
		{
			Task.Factory.StartNew(() =>
			{
				using (router = context.CreateWSRouter())
				using (publisher = context.CreateWSPublisher())
				{
					poller = new Poller();
					router.Bind(routerConnectionString);
					publisher.Bind(publisherConnectionString);

					router.ReceiveReady += GiveConnectionId;

					poller.AddSocket(router);
					poller.Start();
				}
			}, TaskCreationOptions.LongRunning);
		}

		private void GiveConnectionId(object sender, WSSocketEventArgs args)
		{
			var identity = args.WSSocket.Receive();
			var receivedMessage = args.WSSocket.ReceiveString();
			
			if (receivedMessage == "#id")
			{
				args.WSSocket.SendMore(identity).Send(Guid.NewGuid().ToString());
			}
		}

		public void Stop()
		{
			poller.Stop();
		}

		public void Send(string connectionId, string message)
		{
			publisher.SendMore(connectionId).Send(message);
		}
	}
}