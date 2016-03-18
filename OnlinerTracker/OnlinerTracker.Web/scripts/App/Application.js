angular.module("AccountModule", []);
angular.module("HomeModule", []);
angular.module("AdminModule", []);

var main = angular.module("MainApp", ["ngRoute", "AccountModule", "HomeModule"]);

main.config(function ($routeProvider, $locationProvider) {
	$routeProvider.when("/Account", {
		templateUrl: "/scripts/App/Account/Views/SignIn.html",
		controller: "AccountCtrl"
	});

	$routeProvider.when("/Home", {
		templateUrl: "/scripts/App/Home/Views/Search.html",
		controller: "SearchCtrl"
	});

	$routeProvider.otherwise({
		redirectTo: "/Account"
	});
});