using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using OnlinerTracker.DataAccess.Implementations.Ef;
using OnlinerTracker.Web.App_Start;

namespace OnlinerTracker.Web
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			//Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
		}
	}
}