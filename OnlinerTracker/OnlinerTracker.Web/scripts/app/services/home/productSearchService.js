angular.module("OnlinerTracker.Services")
.factory("ProductSearchService", function ($http, $log, URLS) {
	var pageNumber = 1;
	var pageSize = 25;
	var isLoading = false;

	var rejectedFn = function (response) {
		$log.error("Search rejected");
		isLoading = false;
	}

	var emptyResult = {
		page: {
			current: 0,
			last: 0
		},
		products: []
	};

	var find = function (productName, callback) {
		if (!productName) {
			$log.error("Product name is null or empty, returning empty result");
			callback(emptyResult);
			return;
		}

		if (isLoading) {
			$log.warn("Content is loading");
			return;
		}

		if (!angular.isFunction(callback)) {
			$log.error("Callback fn is not a function");
			return;
		}

		isLoading = true;

		// TODO: ЗАПИЛИТЬ ФОРМАТИРОВАНИЕ СТРОКИ $interpolate в помощь
		var url = URLS.SEARCH_PRODUCTS + productName + "/page/" + pageNumber + "/size/" + pageSize;
		$http.get(url).then(function (response) {
			isLoading = false;
			callback(response.data);
		}, rejectedFn);
	}

	return {
		find: find
	}
})