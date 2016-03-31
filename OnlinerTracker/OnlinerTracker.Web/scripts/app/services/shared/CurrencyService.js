angular.module("OnlinerTracker.Services")
.factory("CurrencyService", function ($http, $log, $localStorage, CurrencyRepository) {

	var get = function() {
		return CurrencyRepository.get();
	}

	return {
		get: get
	}
});