function ManageController($scope, $http, $uibModal, $location, ProductTrackingService, CurrencyService,  UserInfoService, ROUTES, VIEW_URLS) {

	$scope.filterQuery = "";
	$scope.items = ProductTrackingService.get();
	$scope.userInfo = UserInfoService.get();
	$scope.page = {
		current: 0,
		last: 0
	};

	var applyUserChanges = function (response) {
		UserInfoService.update(response);
	}

	$scope.showSettingsWindow = function () {
		var seettingsModalInstanse = $uibModal.open({
			animation: true,
			templateUrl: VIEW_URLS.SETTINGS,
			size: "lg",
			controller: "SettingsController",
			backdrop: false,
			resolve: {
				userInfo: function() {
					return $scope.userInfo;
				},
				currency: function() {
					return CurrencyService.get();
				}
			}
		});

		seettingsModalInstanse.result.then(applyUserChanges);
	};

	$scope.toHome = function () {
		$location.path(ROUTES.HOME);
	}

	$scope.trackProduct = function(product) {
		if (product.is_tracked) {
			ProductTrackingService.track(product);
		} else {
			ProductTrackingService.untrack(product);
		}
	}

	$scope.removeProduct = function(product, index) {
		ProductTrackingService.remove(product);
	}

	$scope.trackIncrease = function (product) {
		ProductTrackingService.trackIncrease(product);
	}

	$scope.trackDecrease = function (product) {
		ProductTrackingService.trackDecrease(product);
	}
};

angular.module("OnlinerTracker.Controllers").controller("ManageController", ManageController);