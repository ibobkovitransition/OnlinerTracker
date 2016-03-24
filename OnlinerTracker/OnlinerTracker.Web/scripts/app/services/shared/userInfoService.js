angular.module("OnlinerTracker.Services")
.factory("UserInfoService", function ($http, $log, UserInfoRepository, URLS, $filter) {

	var get = function() {
		return UserInfoRepository.get();
	}

	var update = function (userInfo) {
		var entity = {};
		angular.copy(userInfo, entity);

		entity.settings.prefered_time = $filter("date")(userInfo.settings.prefered_time, "HH:mm");
		entity.settings.selected_currency = userInfo.settings.selected_currency.CharCode;

		$http.put(URLS.USER_UPDATE + userInfo.id, entity).then(function () {
			$log.error("User info update (success)");
		}, function(response) {
			$log.error("User info update (rejected)", response);
		});
	}

	return {
		get: get,
		update: update
	}
})