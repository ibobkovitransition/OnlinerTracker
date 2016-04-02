angular.module("OnlinerTracker.Services")
.factory("SignalrService", function ($http, $log, $cookies, AlertService, COOKIE_KEYS) {

	(function () {
		var connection = $.connection("/echo");
		connection.received(function (data) {
			AlertService.showAlert(data, 750);
		});

		connection.start().done(function () {
			var clientId = connection.id;
			$cookies.put(COOKIE_KEYS.USER_CONNECTION_ID, clientId);
			$log.log("connection is started with ", clientId);
		});
	})();

	return {
		init: function () {
			// переназвать в другой сервис, сомтреть что используется zeroMq или SignalR
		}
	};
});