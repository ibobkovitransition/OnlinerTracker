using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OnlinerTracker.Web.Infrastructure.SignalR.OwinStartup))]

namespace OnlinerTracker.Web.Infrastructure.SignalR
{
	public class OwinStartup
	{
		public void Configuration(IAppBuilder app)
		{
			// запускать в зависимости от IConfig
			// в это случае, можно контролировать запуск NetMq или signalR и не лезть в js
			app.MapSignalR<Context>("/echo");
		}
	}
}
