angular.module("OnlinerTracker.Services")
.factory("userInfoService", function ($http, $log) {

	var isLoading = false;

	var load = function (callback) {
		if (isLoading) {
			$log.info("UserInfo is loading now");
		}

		isLoading = true;
		$http.get("/user/info").then(function (resonse) {
			isLoading = false;
			callback(resonse.data);
		}, function (response) {
			$log.log("Load user info (rejected)", response);
			isLoading = false;
		});
	}

	var update = function (userInfo) {
		$log.log(userInfo);
		$http.put("/user/update/" + userInfo.id, userInfo).then(function(response) {
			$log.log(response);
		}, function(response) {
			$log.log(response);
		});
	}

	return {
		load: load,
		update: update
	}
})