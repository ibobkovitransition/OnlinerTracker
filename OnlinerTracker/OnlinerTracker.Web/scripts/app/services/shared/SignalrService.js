angular.module("OnlinerTracker.Services")
.factory("SignalrService", function ($http, $log, $timeout) {

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
			fadeoutAlert(data, 1250);
		});

		connection.start().done(function () {
			$log.log("connection is started");
		});
	})();

	return {
		init: function () {
			//$log.log(connection);
		}
	};
});