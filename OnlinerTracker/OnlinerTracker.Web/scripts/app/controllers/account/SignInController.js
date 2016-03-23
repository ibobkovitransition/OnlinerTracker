function SignInController($scope, authService, $window) {
	var redirectToSocialNetworkPage = function (response) {
		$window.location.href = response.data;
	}

	$scope.signInWith = function(socialNetworkName) {
		authService.getRequestUrl(socialNetworkName, redirectToSocialNetworkPage);
	}
}

angular.module("OnlinerTracker.Controllers").controller("SignInController", SignInController);