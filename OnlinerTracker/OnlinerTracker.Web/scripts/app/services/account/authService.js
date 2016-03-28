﻿angular.module("OnlinerTracker.Services")
.factory("AuthService", function ($http, $log, $cookies, AppInitializeService, URLS) {

	var getRequestUrl = function (socialNetworkName, callback) {
		$log.log("start", socialNetworkName);
		$http.get(URLS.SIGN_IN + socialNetworkName).then(function (response) {
			$log.log("Redirecting to ", response.data);
			callback(response);
		}, function (response) {
			$log.error("SignIn error", response);
		});
	}

	var logout = function () {
		$cookies.remove("onliner_tracker");
		AppInitializeService.clear();
	}

	return {
		getRequestUrl: getRequestUrl,
		logout: logout
	}
})