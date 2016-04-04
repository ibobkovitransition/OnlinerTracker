using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.BuilderProperties;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.Web.Infrastructure.SignalR;
using Owin;

[assembly: OwinStartup(typeof(OnlinerTracker.Web.App_Start.OwinStartup))]

namespace OnlinerTracker.Web.App_Start
{
	public class OwinStartup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = GlobalHost.DependencyResolver.Resolve<IConfig>();
			var netMq = GlobalHost.DependencyResolver.Resolve<Infrastructure.NetMq.Context>();

			if (config.UseNetMq)
			{
				app.Map("/netmq", builder =>
				{
					netMq.Start();
				});

				HandleClosing(app, netMq);
			}
			else
			{
				app.MapSignalR<Context>(config.SignalrUri);
			}
		}

		private static void HandleClosing(IAppBuilder app, Infrastructure.NetMq.Context netMq)
		{
			var properties = new AppProperties(app.Properties);
			var token = properties.OnAppDisposing;
			if (token != CancellationToken.None)
			{
				token.Register(netMq.Stop);
			}
		}
	}
}
