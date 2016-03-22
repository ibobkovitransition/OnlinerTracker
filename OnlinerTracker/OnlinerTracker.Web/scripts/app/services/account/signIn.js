angular.module("account")
.factory("signIn", function ($http, $window, $log) {
	var url = "/signin/";

	var redirectToSocialNetworkPage = function (response) {
		$log.log("Redirecting to ", response.data);
		$window.location.href = response.data;
	}

	var printError = function(response) {
		$log.error("SignIn error", response);
	}

	var getRequestUrl = function (socialNetworkName) {
		$http.get(url + socialNetworkName).then(redirectToSocialNetworkPage, printError);
	}

	return {
		getRequestUrl: getRequestUrl
	}
})