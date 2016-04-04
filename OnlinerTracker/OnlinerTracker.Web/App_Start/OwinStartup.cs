using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
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
			}
			else
			{
				app.MapSignalR<Context>(config.SignalrUri);
			}
		}
	}
}
