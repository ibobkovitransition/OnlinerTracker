angular.module("AccountModule", []);
angular.module("HomeModule", []);
angular.module("AdminModule", []);

var main = angular.module("MainApp", ["ngRoute", "AccountModule"]);

main.config(function ($routeProvider, $locationProvider) {
	$routeProvider.when("/Account", {
		templateUrl: "/scripts/App/Account/Views/SignIn.html",
		controller: "AccountCtrl"
	});

	$routeProvider.when("/Home", {
		templateUrl: "/scripts/App/Home/Views/Home.html",
		controller: "AccountCtrl"
	});

	$routeProvider.otherwise({
		redirectTo: "/Account"
	});

	//$locationProvider.html5Mode({
	//	enabled: true,
	//	requireBase: false
	//});
});