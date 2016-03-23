angular.module("OnlinerTracker.Services")
.factory("authService", function ($http, $log) {
	var signInUrl = "/signin/";

	var getRequestUrl = function (socialNetworkName, callback) {
		$log.log("start", socialNetworkName);
		$http.get(signInUrl + socialNetworkName).then(function (response) {
			$log.log("Redirecting to ", response.data);
			callback(response);
		}, function (response) {
			$log.error("SignIn error", response);
		});
	}

	var logout = function () {
		// remove cookie
	}

	return {
		getRequestUrl: getRequestUrl,
		logout: logout
	}
})