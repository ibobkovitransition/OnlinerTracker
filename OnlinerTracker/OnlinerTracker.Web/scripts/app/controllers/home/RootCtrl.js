function RootCtrl($scope) {
	$scope.userConfig = {
		name: "ivan",
		email: "1141@mail.com",
		settings: {
			preferedTime: "19:00",
			currentCurrency: ""
		}
	};

	$scope.currencyList = [];

	// load data
	console.log("ROOOT");
};

angular.module("home").controller("RootCtrl", RootCtrl);