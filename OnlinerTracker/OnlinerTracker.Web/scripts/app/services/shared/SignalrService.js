angular.module("OnlinerTracker.Services")
.factory("SignalrService", function ($http, $log, $timeout, $cookies, COOKIE_KEYS) {

	var fadeoutAlert = function (content, delay) {
		$("#notify-alert").show();
		$("#notify-alert > #alert-content").text(content);
		$timeout(function () {
			$("#notify-alert").hide();
		}, delay);
	};

	(function () {
		var connection = $.connection("/echo");
		connection.received(function (data) {
			$log.log(data);
			fadeoutAlert(data, 1250);
		});

		connection.start().done(function () {
			var clientId = connection.id;
			$cookies.put(COOKIE_KEYS.USER_CONNECTION_ID, clientId);

			$log.log("connection is started with ", clientId);
		});
	})();

	return {
		init: function () {
			//$log.log(connection);
		}
	};
});