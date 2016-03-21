using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OnlinerTracker.Web.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/angular")
				.Include("~/scripts/angular.js")
				.Include("~/scripts/angular-resource.js")
				.Include("~/scripts/angular-route.js"));

			bundles.Add(new StyleBundle("~/bundles/styles")
				.Include("~/content/styles.css"));

			bundles.Add(new ScriptBundle("~/bundles/application")
				
				.Include("~/scripts/App/Application.js")
				.Include("~/scripts/App/Account/Controllers/AccountCtrl.js")
				.Include("~/scripts/App/Home/Controllers/SearchCtrl.js")
				
			);

			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/scripts/jquery-1.9.1.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap")
				.Include("~/scripts/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr")
				.Include("~/scripts/jmodernizr-2.8.3.js"));

			bundles.Add(new StyleBundle("~/bundles/bootstrap-css")
				.Include("~/content/bootstrap.css")
				.Include("~/content/bootstrap-theme.css")
				.Include("~/content/font-awesome.css")
				.Include("~/content/bootstrap-social.css"));
		}
	}
}