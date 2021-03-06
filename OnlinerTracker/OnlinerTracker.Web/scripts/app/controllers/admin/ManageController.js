﻿function ManageController(
	$scope,
	$uibModal,
	$location,
	AuthService,
	ProductTrackingService,
	CurrencyService,
	UserInfoService,
	ROUTES,
	VIEW_URLS) {

	$scope.filterQuery = "";
	$scope.items = ProductTrackingService.get();
	$scope.userInfo = UserInfoService.get();
	$scope.currency = CurrencyService.get();
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
				userInfo: function () {
					return $scope.userInfo;
				},
				currency: function() {
					return $scope.currency;
				}
			}
		});

		seettingsModalInstanse.result.then(applyUserChanges);
	};

	$scope.toHome = function () {
		$location.path(ROUTES.HOME);
	}

	$scope.logout = function() {
		$location.path(ROUTES.AUTH);
		AuthService.logout();
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
		$scope.items.splice(index, 1);	
	}

	$scope.trackIncrease = function (product) {
		ProductTrackingService.trackIncrease(product);
	}

	$scope.trackDecrease = function (product) {
		ProductTrackingService.trackDecrease(product);
	}
};

angular.module("OnlinerTracker.Controllers").controller("ManageController", ManageController);