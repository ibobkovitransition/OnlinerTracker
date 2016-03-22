angular.module("infiniteScroll", []);

angular.module("account", []);
angular.module("home", ["infiniteScroll"]);
angular.module("admin", ["infiniteScroll"]);

angular.module("MainApp", ["ngRoute", "account", "home", "admin"])
.config(function ($routeProvider) {
	$routeProvider.when("/Account", {
		templateUrl: "/scripts/app/views/account/signin.html",
		controller: "SignInController"
	});

	$routeProvider.when("/Home", {
		templateUrl: "/scripts/app/views/home/search.html",
		controller: "SearchController"
	});

	$routeProvider.when("/Admin", {
		templateUrl: "/scripts/app/views/admin/manage.html",
		controller: "AdminController"
	});

	$routeProvider.otherwise({
		redirectTo: "/Account"
	});
});