angular.module("OnlinerTracker.Services")
.factory("AuthService", function ($http, $log, $cookies, InitializeService, URLS, COOKIE_KEYS) {

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
		$cookies.remove(COOKIE_KEYS.USER_ID);
		$cookies.remove(COOKIE_KEYS.USER_CONNECTION_ID);
		InitializeService.clear();
	}

	return {
		getRequestUrl: getRequestUrl,
		logout: logout
	}
})