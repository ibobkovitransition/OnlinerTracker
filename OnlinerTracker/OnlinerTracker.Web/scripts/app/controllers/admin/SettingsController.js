function SettingsController($scope, $uibModalInstance, userInfo, currency) {

	$scope.userInfo = userInfo;
	$scope.currency = currency;

	$scope.save = function () {
		$uibModalInstance.close($scope.userInfo);
	}

	$scope.click = function(userInfoForm) {
		console.log(userInfoForm.$invalid);
		console.log(userInfoForm.$error);
	}

	$scope.cancel = function () {
		$uibModalInstance.dismiss("cancel");
	}
};

angular.module("OnlinerTracker.Controllers").controller("SettingsController", SettingsController);