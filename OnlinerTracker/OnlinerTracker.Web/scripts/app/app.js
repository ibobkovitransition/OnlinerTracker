angular.module("infiniteScroll", []);

angular.module("account", []);
angular.module("home", ["infiniteScroll"]);
angular.module("admin", ["infiniteScroll"]);

angular.module("MainApp", ["ngRoute", "account", "home", "admin"])
.config(function ($routeProvider) {
	$routeProvider.when("/Account", {
		templateUrl: "/scripts/app/views/account/signin.html",
		controller: "SignInCtrl"
	});

	$routeProvider.when("/Home", {
		templateUrl: "/scripts/app/views/home/search.html",
		controller: "ProductSearchCtrl"
	});

	$routeProvider.otherwise({
		redirectTo: "/Account"
	});
});