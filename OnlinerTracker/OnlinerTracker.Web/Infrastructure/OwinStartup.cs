using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OnlinerTracker.Web.Infrastructure.OwinStartup))]

namespace OnlinerTracker.Web.Infrastructure
{
	public class OwinStartup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR<SignalrContext>("/echo");
		}
	}
}
