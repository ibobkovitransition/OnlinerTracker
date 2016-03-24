angular.module("OnlinerTracker.Services")
.factory("UserInfoService", function ($http, $log, UserInfoRepository) {

	var get = function() {
		return UserInfoRepository.get();
	}

	var update = function (userInfo) {
		$log.log(userInfo);
	}

	return {
		get: get,
		update: update
	}
})