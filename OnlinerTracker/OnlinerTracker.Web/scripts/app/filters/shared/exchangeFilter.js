angular.module("OnlinerTracker.Filters", [])
.filter("exchangeFilter", function ($filter) {
	return function (value, rate) {
		return  $filter("number")(value / rate, 0);
	};
});