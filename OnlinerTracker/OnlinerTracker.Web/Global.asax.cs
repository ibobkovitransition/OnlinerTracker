using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using Microsoft.AspNet.SignalR;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.Web.App_Start;

namespace OnlinerTracker.Web
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			WebApiFiltersConfig.Register(GlobalConfiguration.Configuration.Filters);

			GlobalHost.DependencyResolver.Register(typeof(IConfig), () => DependencyResolver.Current.GetService<IConfig>());
			GlobalHost.DependencyResolver.Register(typeof(Infrastructure.NetMq.Context), () => DependencyResolver.Current.GetService<Infrastructure.NetMq.Context>());

			// не работает с новым Resolver'ом
			//GlobalHost.DependencyResolver = new SignalrDependencyResolver(DependencyResolver.Current.GetService<DefaultDependencyResolver>());
		}
	}
}