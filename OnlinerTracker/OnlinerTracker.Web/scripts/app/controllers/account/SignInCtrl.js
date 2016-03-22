function SignInCtrl($scope, signIn) {
	$scope.signInWith = function(socialNetworkName) {
		signIn.getRequestUrl(socialNetworkName);
	}
}

angular.module("account").controller("SignInCtrl", SignInCtrl);