angular.module("OnlinerTracker.Services")
.factory("AppInitializeService", function ($http, $log, $localStorage) {

	var userInfoUrl = "/user/info";
	var currencyInfoUrl = "/currency";
	var productTrackingUrl = "/tracking/products";

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

	var load = function () {
		$log.log("User info (start)");
		$http.get(userInfoUrl).then(userInfoCallback, function (response) {
			$log.error("User info (rejected)", response);
		});

		$log.log("Currency (start)");
		$http.get(currencyInfoUrl).then(currencyCallback, function (response) {
			$log.error("Currency (rejected)", response);
		});

		$log.log("ProductTracking (start)");
		$http.get(productTrackingUrl).then(productTrackingCallback, function (response) {
			$log.error("ProductTracking (rejected)", response);
		});
	}

	return {
		init: load
	}
});