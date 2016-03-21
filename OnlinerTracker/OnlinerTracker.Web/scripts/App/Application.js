angular.module("AccountModule", []);
angular.module("HomeModule", []);
angular.module("AdminModule", []);

angular.module("MainApp", ["ngRoute", "AccountModule", "HomeModule", "AdminModule"])
.config(function ($routeProvider) {
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