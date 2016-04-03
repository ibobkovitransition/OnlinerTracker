using System.Threading.Tasks;
using NetMQ;
using NetMQ.WebSockets;
using Ninject;

namespace OnlinerTracker.Web.Infrastructure
{
	public class NetMqWebSocketsContext : IStartable
	{
		private readonly NetMQContext context;
		private Poller poller;
		private WSRouter router;
		private WSPublisher publisher;

		// TODO: вынести в IWebConfig
		// TODO: спросить, допускается ли применение синглотона для этого чуда? во что следует вынести сие чудо?
		// TODO: начуится передавать id подключения клиенту
		// смотреть в сторону каких-нибудь IHttpModule, но я не знаю на сколько это хрошая идея
		private string routerConnectionString = "ws://localhost:82";
		private string publisherConnectionString = "ws://localhost:83";

		public NetMqWebSocketsContext(NetMQContext context)
		{
			this.context = context;
		}

		public void Start()
		{
			Task.Factory.StartNew(() =>
			{
				poller = new Poller();
				router = context.CreateWSRouter();
				publisher = context.CreateWSPublisher();

				// получить identity,
				// если не разберусь, то: 
				// при получении строки вида fetch_id
				// юзать Guid.New guid
				// и отдавать пользователю в формате your_id: 0000-00000-00000-00000
				// в свою очередь, он пусть ложит это приблуду в куки, ну а дальше по накатанной

				router.Bind(routerConnectionString);
				publisher.Bind(publisherConnectionString);

				poller = new Poller();
				poller.AddSocket(router);
				poller.Start();
			}, TaskCreationOptions.LongRunning);
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