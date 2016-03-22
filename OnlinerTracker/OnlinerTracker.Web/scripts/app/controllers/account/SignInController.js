function SignInController($scope, signIn, $log, $window) {
	var redirectToSocialNetworkPage = function (response) {
		$log.log("Redirecting to ", response.data);
		$window.location.href = response.data;
	}

	$scope.signInWith = function(socialNetworkName) {
		signIn.getRequestUrl(socialNetworkName, redirectToSocialNetworkPage);
	}
}

angular.module("account").controller("SignInController", SignInController);