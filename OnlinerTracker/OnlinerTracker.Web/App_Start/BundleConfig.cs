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
				.Include("~/scripts/angular-route.js")
				.Include("~/scripts/angular-animate.js")
				.Include("~/scripts/angular-ui/ui-bootstrap-tpls.js"));

			bundles.Add(new StyleBundle("~/bundles/styles")
				.Include("~/content/styles.css"));

			bundles.Add(new ScriptBundle("~/bundles/application")
				.Include("~/scripts/app/app.js")
				.Include("~/scripts/app/controllers/account/SignInController.js")
				.Include("~/scripts/app/controllers/home/SearchController.js")
				.Include("~/scripts/app/controllers/admin/ManageController.js")
				.Include("~/scripts/app/controllers/admin/SettingsController.js")

				.Include("~/scripts/app/services/account/authService.js")
				.Include("~/scripts/app/services/home/productSearchService.js")
				.Include("~/scripts/app/services/home/productUploadService.js")
				.Include("~/scripts/app/services/shared/productTrackingService.js")
				.Include("~/scripts/app/services/shared/userInfoService.js")

				.Include("~/scripts/app/directives/home/infiniteScroll.js")
			);

			// выкосить
			//bundles.Add(new ScriptBundle("~/bundles/jquery")
			//	.Include("~/scripts/jquery-1.9.1.js"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap")
			//	.Include("~/scripts/bootstrap.js"));
			//// 

			//bundles.Add(new ScriptBundle("~/bundles/modernizr")
			//	.Include("~/scripts/jmodernizr-2.8.3.js"));
			

			bundles.Add(new StyleBundle("~/bundles/bootstrap-css")
				.Include("~/content/bootstrap.css")
				.Include("~/content/bootstrap-theme.css")
				.Include("~/content/font-awesome.css")
				.Include("~/content/bootstrap-social.css"));
		}
	}
}