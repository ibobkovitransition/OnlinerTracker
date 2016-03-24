angular.module("OnlinerTracker.Services")
.factory("AppInitializeService", function ($http, $log, $localStorage, URLS) {

	var userInfoCallback = function (response) {
		$log.log("User info (success)");
		$localStorage.userInfo = response.data;
		$localStorage.userInfo.settings.prefered_time = new Date("2000-01-01T" + $localStorage.userInfo.settings.prefered_time);
	}

	var currencyCallback = function (response) {
		$log.log("Currency (success)");
		$localStorage.currency = response.data;
		$localStorage.currency.unshift({
			CharCode: "BUR"
		});
	}

	var productTrackingCallback = function (response) {
		$log.log("Product tracking (success)");
		$localStorage.productTracking = response.data;
	}

	var load = function () {
		$log.log("User info (start)");
		$http.get(URLS.USER_INFO).then(userInfoCallback, function (response) {
			$log.error("User info (rejected)", response);
		});

		$log.log("Currency (start)");
		$http.get(URLS.CURRENCY).then(currencyCallback, function (response) {
			$log.error("Currency (rejected)", response);
		});

		$log.log("ProductTracking (start)");
		$http.get(URLS.PRODUCT_TRACKING).then(productTrackingCallback, function (response) {
			$log.error("ProductTracking (rejected)", response);
		});
	}

	return {
		init: load
	}
});