using Microsoft.Owin;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using Owin;

[assembly: OwinStartup(typeof(OnlinerTracker.Web.Infrastructure.SignalR.OwinStartup))]

namespace OnlinerTracker.Web.Infrastructure.SignalR
{
	public class OwinStartup
	{
		private readonly IConfig config;

		//public OwinStartup(IConfig config)
		//{
		//	this.config = config;
		//}

		public void Configuration(IAppBuilder app)
		{
			// запускать в зависимости от IConfig
			// в это случае, можно контролировать запуск NetMq или signalR и не лезть в js
			//app.MapSignalR<Context>(config.SignalrUri);
			app.MapSignalR<Context>("/echo");
		}
	}
}
