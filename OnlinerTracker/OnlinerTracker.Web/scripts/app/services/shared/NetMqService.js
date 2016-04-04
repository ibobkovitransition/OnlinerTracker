angular.module("OnlinerTracker.Services")
.factory("NetMqService", function ($log, $cookies, AlertService, COOKIE_KEYS, NETMQ) {

	var dealer = new JSMQ.Dealer();
	var subscriber = new JSMQ.Subscriber();
	var initialized = false;

	dealer.sendReady = function () {
		var message = new JSMQ.Message();
		message.addString("#id");
		dealer.send(message);
	};

	dealer.onMessage = function (message) {
		connectionId = message.popString();
		subscriber.subscribe(connectionId);
		$cookies.put(COOKIE_KEYS.USER_CONNECTION_ID, connectionId);
		$log.info("NetMq connection successful");
	}

	subscriber.onMessage = function (message) {
		message.popString();
		AlertService.showAlert(message.popString(), 1500);
	}

	return {
		init: function () {
			if (!initialized) {
				dealer.connect(NETMQ.DEALER);
				subscriber.connect(NETMQ.PUBLISHER);
				initialized = true;
			}
		}
	};
});