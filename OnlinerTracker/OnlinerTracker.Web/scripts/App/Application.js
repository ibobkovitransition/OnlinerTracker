
angular.module("AuthModule", []);
angular.module("HomeModule", []);
angular.module("AdminModule", []);

var main = angular.module("MainApp", ["ngRoute"]);

//main.config(function ($routeProvider) {
//	$routeProvider.when("/Auth", {
//		templateUrl: "/Scripts/App/Auth/Views/Auth.html",
//		controller: "AuthCtrl"
//	});
//});