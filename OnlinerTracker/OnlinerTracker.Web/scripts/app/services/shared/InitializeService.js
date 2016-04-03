angular.module("OnlinerTracker.Services")
.factory("InitializeService", function ($http, $log, $localStorage, URLS) {

	var initialized = false;

	var initializeUserInfoRepository = function (response) {
		$localStorage.userInfo = response.data;
		$log.info("UserInfo repository inited");
	}

	var initializeCurrencyRepository = function (response) {
		$localStorage.currency = response.data;
		$log.info("Currency repository inited");
	}

	var initializeProductTrackingRepository = function (response) {
		$localStorage.productTracking = response.data;
		$log.info("ProductTracking repository inited");
	}

	var insertDefaultCurrency = function () {
		$localStorage.currency.unshift({
			CharCode: "BUR",
			Rate: 1
		});
	}

	var setupUserInfo = function () {
		$localStorage.userInfo.settings.prefered_time = new Date(Date.parse("1970/01/01 " + $localStorage.userInfo.settings.prefered_time));
		$localStorage.userInfo.settings.selected_currency = $localStorage.currency[0];
	}

	var setupData = function () {
		$log.info("Setup data");
		insertDefaultCurrency();
		setupUserInfo();
	}

	var rejectCallBack = function (response) {
		$log.error("Loading error", response);
	}

	var clearStore = function () {
		$log.info("Clear storage");
		$localStorage.$reset();
		initialized = false;
	}

	var load = function () {
		if (initialized) {
			return null;
		}

		$log.info("Initialize repositories");

		return $http.get(URLS.CURRENCY)
			.then(function (response) {
				initializeCurrencyRepository(response);
				return $http.get(URLS.PRODUCT_TRACKING);
			}, rejectCallBack).then(function (response) {
				initializeProductTrackingRepository(response);
				return $http.get(URLS.USER_INFO);
			}, rejectCallBack).then(function (response) {
				initializeUserInfoRepository(response);
				setupData();
				initialized = true;
			}, rejectCallBack);
	}

	return {
		init: load,
		clear: clearStore
	}
});