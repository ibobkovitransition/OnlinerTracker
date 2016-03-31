angular.module("OnlinerTracker.Services")
.factory("UserInfoService", function ($http, $log, UserInfoRepository, URLS, $filter) {

	var currentUser = null;

	var get = function () {
		if (!currentUser) {
			currentUser = UserInfoRepository.get();
		}

		return currentUser;
	}

	var update = function (userInfo) {
		currentUser = userInfo;
		UserInfoRepository.update(userInfo);

		var entity = {};
		angular.copy(userInfo, entity);

		// парсим в пригодный для сервера вид
		entity.settings.prefered_time = $filter("date")(userInfo.settings.prefered_time, "HH:mm");
		entity.settings.selected_currency = userInfo.settings.selected_currency.CharCode;

		$http.put(URLS.USER_UPDATE + userInfo.id, entity).then(function () {
			$log.error("User info update (success)");
		}, function (response) {
			$log.error("User info update (rejected)", response);
		});
	}

	return {
		get: get,
		update: update
	}
})