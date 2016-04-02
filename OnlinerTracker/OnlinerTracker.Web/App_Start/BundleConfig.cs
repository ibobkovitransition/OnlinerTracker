using System.Web.Optimization;

namespace OnlinerTracker.Web.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/angular")
				.Include("~/scripts/angular.js")
				.Include("~/scripts/angular-cookies.js")
				.Include("~/scripts/angular-resource.js")
				.Include("~/scripts/angular-route.js")
				.Include("~/scripts/angular-animate.js")
				.Include("~/scripts/ngStorage.js")
				.Include("~/scripts/angular-ui/ui-bootstrap-tpls.js"));

			bundles.Add(new StyleBundle("~/bundles/styles")
				.Include("~/content/styles.css"));

			bundles.Add(new ScriptBundle("~/bundles/application")
				.Include("~/scripts/app/app.js")
				.Include("~/scripts/app/controllers/account/SignInController.js")
				.Include("~/scripts/app/controllers/home/SearchController.js")
				.Include("~/scripts/app/controllers/admin/ManageController.js")
				.Include("~/scripts/app/controllers/admin/SettingsController.js")

				.Include("~/scripts/app/repositories.js")
				.Include("~/scripts/app/services/account/AuthService.js")
				.Include("~/scripts/app/services/home/ProductSearchService.js")
				.Include("~/scripts/app/services/home/ProductUploadService.js")
				.Include("~/scripts/app/services/shared/ProductTrackingService.js")
				.Include("~/scripts/app/services/shared/UserInfoService.js")
				.Include("~/scripts/app/services/shared/AppInitializeService.js")
				.Include("~/scripts/app/services/shared/CurrencyService.js")
				.Include("~/scripts/app/services/shared/SignalrService.js")
				.Include("~/scripts/app/services/shared/AlertService.js")

				.Include("~/scripts/app/filters/shared/exchangeFilter.js")
				.Include("~/scripts/app/directives/shared/infiniteScroll.js")
				.Include("~/scripts/app/directives/shared/anchor.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/scripts/jquery-1.9.1.js"));

			bundles.Add(new ScriptBundle("~/bundles/signalr")
				.Include("~/scripts/jquery.signalR-2.2.0.js"));

			bundles.Add(new StyleBundle("~/bundles/bootstrap-css")
				.Include("~/content/bootstrap.css")
				.Include("~/content/bootstrap-theme.css")
				.Include("~/content/font-awesome.css")
				.Include("~/content/bootstrap-social.css"));
		}
	}
}