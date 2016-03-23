function ManageController($scope, $http, $uibModal, $location, productTrackingService, userInfoService) {

	// вынести во внешний контроллер
	$scope.filterQuery = "";
	$scope.items = [];
	$scope.userInfo = {};
	$scope.page = {
		current: 0,
		last: 0
	};

	(function () {
		userInfoService.load(function (userInfo) {
			$scope.userInfo = userInfo;
		});
	})();

	(function () {
		productTrackingService.get(function(response) {
			$scope.items = response;
		});
	})();

	var applyUserChanges = function (response) {
		userInfoService.update(response);
	}

	$scope.showSettingsWindow = function () {
		var seettingsModalInstanse = $uibModal.open({
			animation: true,
			templateUrl: "scripts/app/views/admin/settings.html",
			size: "lg",
			controller: "SettingsController",
			backdrop: false,
			resolve: {
				userInfo: function() {
					return $scope.userInfo;
				}
			}
		});

		seettingsModalInstanse.result.then(applyUserChanges);
	};

	$scope.toHome = function () {
		$location.path("/Home");
	}

	$scope.trackProduct = function(product) {
		if (product.is_tracked) {
			productTrackingService.track(product);
		} else {
			productTrackingService.untrack(product);
		}
	}

	$scope.removeProduct = function(product, index) {
		productTrackingService.remove(product);
		$scope.items.splice(index, 1);
	}

	$scope.trackIncrease = function (product) {
		productTrackingService.trackIncrease(product);
	}

	$scope.trackDecrease = function (product) {
		productTrackingService.trackDecrease(product);
	}
};

angular.module("OnlinerTracker.Controllers").controller("ManageController", ManageController);