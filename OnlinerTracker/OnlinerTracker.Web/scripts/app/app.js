angular.module("infiniteScroll", []);

angular.module("OnlinerTracker.Repositories", []);
angular.module("OnlinerTracker.Services", []);
angular.module("OnlinerTracker.Filters", []);
angular.module("OnlinerTracker.Controllers", ["ui.bootstrap", "infiniteScroll"]);

var main = angular.module("OnlinerTracker", [
	"ngRoute",
	"ngStorage",
	"ngCookies",
	"OnlinerTracker.Controllers",
	"OnlinerTracker.Services",
	"OnlinerTracker.Repositories",
	"OnlinerTracker.Filters"]);

main.constant("ROUTES", {
	AUTH: "/Account",
	HOME: "/Home",
	ADMIN: "/Admin"
});

main.constant("URLS", {
	SIGN_IN: "/signin/",
	SEARCH_PRODUCTS: "/search/products/",
	USER_INFO: "/user/info",
	USER_UPDATE: "/user/update/",
	CURRENCY: "/currency",
	PRODUCT_TRACKING: "/tracking/products",
	TRACK: "/tracking/start",
	UNTRACK: "/tracking/stop",
	REMOVE: "/tracking/remove",
	INCREASE: "/tracking/increase",
	DECREASE: "/tracking/decrease"
});

main.constant("VIEW_URLS", {
	SIGN_IN: "/scripts/app/views/account/signin.html",
	SEARCH: "/scripts/app/views/home/search.html",
	ADMIN: "/scripts/app/views/admin/manage.html",
	SETTINGS: "/scripts/app/views/admin/settings.html"
});

// https://github.com/mgechev/angularjs-style-guide/blob/master/README-ru-ru.md
// TODO: будет время - сделать https://github.com/angular-ui/ui-router

main.config(function ($routeProvider, ROUTES, VIEW_URLS) {
	$routeProvider.when(ROUTES.AUTH, {
		templateUrl: VIEW_URLS.SIGN_IN,
		controller: "SignInController"
	});

	$routeProvider.when(ROUTES.HOME, {
		templateUrl: VIEW_URLS.SEARCH,
		controller: "SearchController"
	});

	$routeProvider.when(ROUTES.ADMIN, {
		templateUrl: VIEW_URLS.ADMIN,
		controller: "ManageController"
	});

	$routeProvider.otherwise({
		redirectTo: ROUTES.AUTH
	});
});

// https://docs.angularjs.org/guide/module
main.config(["$localStorageProvider", function ($localStorageProvider) {
	// TODO: ВЫСТАВИТЬ ПРЕФИКС
}]);

main.run(function (AppInitializeService) {
	AppInitializeService.init();
});
