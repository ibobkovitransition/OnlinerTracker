
angular.module("AuthModule", []);
angular.module("HomeModule", []);
angular.module("AdminModule", []);

var main = angular.module("MainApp", ["ngRoute", "AuthModule"]);

main.config(function ($routeProvider, $locationProvider) {
	$routeProvider.when("/Auth", {
		templateUrl: "/scripts/App/Auth/Views/Auth.html",
		controller: "AuthCtrl"
	});

	$routeProvider.otherwise({
		redirectTo: "/Auth"
	});

	//$locationProvider.html5Mode({
	//	enabled: true,
	//	requireBase: false
	//});

});