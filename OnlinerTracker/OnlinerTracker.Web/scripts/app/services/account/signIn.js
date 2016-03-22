angular.module("account")
.factory("signIn", function ($http, $log) {
	var url = "/signin/";

	var printError = function(response) {
		$log.error("SignIn error", response);
	}

	var getRequestUrl = function (socialNetworkName, callback) {
		$http.get(url + socialNetworkName).then(callback, printError);
	}

	return {
		getRequestUrl: getRequestUrl
	}
})