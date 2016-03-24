function SettingsController($scope, $uibModalInstance, userInfo, currency) {

	// set currency
	if (userInfo.settings.selected_currency) {
		for (var i = 0; i < currency.length; i++) {

			if (currency[i].CharCode === userInfo.settings.selected_currency) {
				userInfo.settings.selected_currency = currency[i];
				break;
			}
		}
	} else {
		userInfo.settings.selected_currency = currency[0];
	}

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