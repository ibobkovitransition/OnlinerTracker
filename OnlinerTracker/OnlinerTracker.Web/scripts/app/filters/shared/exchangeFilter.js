﻿angular.module("OnlinerTracker.Filters", [])
.filter("exchangeFilter", function ($filter) {
	return function (value, rate) {

		if (isNaN(rate)) {
			rate = 1;
		}

		if (isNaN(value)) {
			return "0";
		}

		return $filter("number")(value / rate, 0);
	};
});