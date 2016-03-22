function ManageController($scope) {

	// вынести во внешний контроллер
	$scope.searchQuery = "";
	$scope.items = [];
	$scope.page = {
		current: 0,
		last: 0
	};

	console.log("Tracking product");
};

angular.module("admin").controller("ManageController", ManageController);