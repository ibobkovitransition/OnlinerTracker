angular.module("OnlinerTracker.Repositories", []);
angular.module("OnlinerTracker.Controllers", []);
angular.module("OnlinerTracker.Directives", []);
angular.module("OnlinerTracker.Services", []);
angular.module("OnlinerTracker.Filters", []);

var main = angular.module("OnlinerTracker", [
	"ui.bootstrap",
	"ngStorage",
	"ngCookies",
	"ngRoute",
	"OnlinerTracker.Repositories",
	"OnlinerTracker.Controllers",
	"OnlinerTracker.Directives",
	"OnlinerTracker.Services",
	"OnlinerTracker.Filters"]);

main.constant("ROUTES", {
	AUTH: "/Account",
	HOME: "/Home",
	ADMIN: "/Admin"
});

main.constant("URLS", {
	SIGN_IN: "/signin/",
	SEARCH_PRODUCTS: "/search/products/",
	USER_INFO: "/user/",
	USER_UPDATE: "/user/",
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

main.constant("COOKIE_KEYS", {
	USER_ID: "onliner_tracker",
	USER_CONNECTION_ID: "connection_id"
});

main.constant("SIGNALR", {
	URI: "/echo"
});

main.constant("NETMQ", {
	DEALER: "ws://localhost:92",
	PUBLISHER: "ws://localhost:93"
});

main.config(function ($routeProvider, ROUTES, VIEW_URLS) {
	$routeProvider.when(ROUTES.AUTH, {
		templateUrl: VIEW_URLS.SIGN_IN,
		controller: "SignInController"
	});

	$routeProvider.when(ROUTES.HOME, {
		templateUrl: VIEW_URLS.SEARCH,
		controller: "SearchController",
		resolve: {
			"InitializeServiceData": function (InitializeService) {
				return InitializeService.init();
			},
			"NetMqServiceData": function(NetMqService) {
				return NetMqService.init();
			},
			 //загружать по условию
			"SignalrServiceData": function(SignalrService) {
				return SignalrService.init();
			}
		}
	});

	$routeProvider.when(ROUTES.ADMIN, {
		templateUrl: VIEW_URLS.ADMIN,
		controller: "ManageController",
		resolve: {
			"InitializeServiceData": function (InitializeService) {
				return InitializeService.init();
			},
			// загружать по условию
			"NetMqServiceData": function (NetMqService) {
				return NetMqService.init();
			},
			 //загружать по условию
			"SignalrServiceData": function (SignalrService) {
				return SignalrService.init();
			}
		}
	});

	$routeProvider.otherwise({
		redirectTo: ROUTES.AUTH
	});
});
