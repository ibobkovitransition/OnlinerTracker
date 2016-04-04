using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OnlinerTracker.Web.Infrastructure.SignalR.OwinStartup))]

namespace OnlinerTracker.Web.Infrastructure.SignalR
{
	public class OwinStartup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR<Context>("/echo");
		}
	}
}
