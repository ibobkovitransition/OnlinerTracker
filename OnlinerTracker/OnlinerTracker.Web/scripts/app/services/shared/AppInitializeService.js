angular.module("OnlinerTracker.Services")
.factory("AppInitializeService", function ($http, $log, $localStorage, URLS) {

	var userInfoCallback = function (response) {
		$log.log("User info (success)");
		$localStorage.userInfo = response.data;
	}

	var currencyCallback = function (response) {
		$log.log("Currency (success)");
		$localStorage.currency = response.data;
	}

	var productTrackingCallback = function (response) {
		$log.log("Product tracking (success)");
		$localStorage.productTracking = response.data;
	}

	var setupData = function () {
		console.log("Init");

		$localStorage.currency.unshift({
			CharCode: "BUR"
		});

		$localStorage.userInfo.settings.prefered_time = new Date("2000-01-01T" + $localStorage.userInfo.settings.prefered_time);
		
		if ($localStorage.userInfo.settings.selected_currency) {
			for (var i = 0; i < $localStorage.currency.length; i++) {

				if ($localStorage.currency[i].CharCode === $localStorage.userInfo.settings.selected_currency) {
					$localStorage.userInfo.settings.selected_currency = $localStorage.currency[i];
					break;
				}
			}
		} else {
			$localStorage.userInfo.settings.selected_currency = $localStorage.currency[0];
		}
	}

	var rejected = function (response) {
		$log.error("Loading error", response);
	}

	var load = function () {
		$http.get(URLS.CURRENCY)
			.then(function (response) {
				currencyCallback(response);
				return $http.get(URLS.PRODUCT_TRACKING);
			}, rejected)
			.then(function (response) {
				productTrackingCallback(response);
				return $http.get(URLS.USER_INFO);
			}, rejected)
			.then(function (response) {
				userInfoCallback(response);
				setupData();
			}, rejected);
	}

	return {
		init: load
	}
});