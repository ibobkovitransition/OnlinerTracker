function SignInController($scope, AuthService, $window) {
	var redirectToSocialNetworkPage = function (response) {
		$window.location.href = response.data;
	}

	$scope.signInWith = function(socialNetworkName) {
		AuthService.getRequestUrl(socialNetworkName, redirectToSocialNetworkPage);
	}
}

angular.module("OnlinerTracker.Controllers").controller("SignInController", SignInController);