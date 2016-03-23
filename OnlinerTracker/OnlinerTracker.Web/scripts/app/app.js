angular.module("infiniteScroll", []);
angular.module("account", []);
angular.module("home", ["ui.bootstrap", "infiniteScroll"]);
angular.module("admin", ["ui.bootstrap", "ui.bootstrap.tpls"]);

angular.module("main", ["ngRoute", "account", "home", "admin"])
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
		controller: "ManageController"
	});

	$routeProvider.otherwise({
		redirectTo: "/Account"
	});
});

// run directive
// init storage