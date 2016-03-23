function SettingsController($scope, $uibModalInstance, userInfo) {

	$scope.userInfo = userInfo;

	//	{
	//	first_name: "",
	//	email: "",
	//	settings: {
	//		default_currency: "",
	//		prefered_time: new Date()
	//	}
	//};


	// returns userinfo
	$scope.save = function () {
		$uibModalInstance.close($scope.userInfo);
	}

	$scope.cancel = function () {
		$uibModalInstance.dismiss("cancel");
	}
};

angular.module("OnlinerTracker.Controllers").controller("SettingsController", SettingsController);