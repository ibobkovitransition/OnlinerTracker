angular.module("infiniteScroll", []);

angular.module("OnlinerTracker.Repositories", []);
angular.module("OnlinerTracker.Services", []);
angular.module("OnlinerTracker.Controllers", ["ui.bootstrap", "infiniteScroll", "infiniteScroll"]);

var main = angular.module("OnlinerTracker", [
	"ngRoute",
	"ngStorage",
	"OnlinerTracker.Controllers",
	"OnlinerTracker.Services",
	"OnlinerTracker.Repositories"]);

main.config(function ($routeProvider) {
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

main.run(function ($localStorage, $sessionStorage) {
	// инициализировать хранилище
	// в данном приложение вызывается два раза
	// первый раз в auth, второй после авторизации
	
	// 
	console.log("run");
	console.log($localStorage);
	console.log($sessionStorage);
});


// run directive
// init storage