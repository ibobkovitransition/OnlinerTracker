function ManageController($scope, $http, $uibModal, $location, productTracking) {

	// вынести во внешний контроллер
	$scope.filterQuery = "";
	$scope.items = [];
	$scope.page = {
		current: 0,
		last: 0
	};

	(function () {
		$http.get("/tracking/products").then(function (response) {
			console.log(response);
			$scope.items = response.data;
		}, function () {

		});
	})();

	var applyUserChanges = function(response) {
		console.log(response);
	}

	$scope.showSettingsWindow = function () {
		var seettingsModalInstanse = $uibModal.open({
			animation: false,
			templateUrl: "scripts/app/views/admin/settings.html",
			//size: "lg",
			controller: "SettingsController",
			backdrop: false
		});

		seettingsModalInstanse.result.then(applyUserChanges);
	};

	$scope.toHome = function () {
		$location.path("/Home");
	}

	$scope.trackProduct = function(product) {
		if (product.is_tracked) {
			productTracking.track(product);
		} else {
			productTracking.untrack(product);
		}
	}

	$scope.removeProduct = function(product, index) {
		productTracking.remove(product);
		$scope.items.splice(index, 1);
	}

	$scope.trackIncrease = function (product) {
		productTracking.trackIncrease(product);
		console.log(product.increase);
	}

	$scope.trackDecrease = function (product) {
		productTracking.trackDecrease(product);
	}


};

angular.module("admin").controller("ManageController", ManageController);