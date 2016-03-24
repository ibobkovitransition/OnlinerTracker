angular.module("OnlinerTracker.Services")
.factory("UserInfoService", function ($http, $log, UserInfoRepository) {

	var get = function() {
		return UserInfoRepository.get();
	}

	var update = function (userInfo) {
		$log.log(userInfo);
		//$http.put("/user/update/" + userInfo.id, userInfo).then(function(response) {
		//	$log.log(response);
		//}, function(response) {
		//	$log.log(response);
		//});
	}

	return {
		get: get,
		update: update
	}
})