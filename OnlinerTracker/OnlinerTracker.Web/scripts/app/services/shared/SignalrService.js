﻿angular.module("OnlinerTracker.Services")
.factory("SignalrService", function ($http, $log, $cookies, AlertService, COOKIE_KEYS) {

	var initialized = false;
	var connection = null;

	var onReceived = function(data) {
		AlertService.showAlert(data, 1500);
	}

	var onConnected = function() {
		$cookies.put(COOKIE_KEYS.USER_CONNECTION_ID, connection.id);
		$log.info("SignalR connection successful");
		initialized = true;
	}

	var initConnection = function () {
		if (initialized) {
			return;
		}

		connection = $.connection("/echo");
		connection.received(onReceived);
		connection.start().done(onConnected);
	};

	return {
		init: initConnection
	};
});