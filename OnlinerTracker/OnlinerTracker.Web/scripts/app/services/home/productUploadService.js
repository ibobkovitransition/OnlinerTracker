angular.module("OnlinerTracker.Services")
.factory("ProductUploadService", function ($http, $log) {
	var pageSize = 25;
	var isLoading = false;

	var rejectedFn = function (response) {
		$log.error("Upload rejected");
		isLoading = false;
	}

	var emptyResult = {
		page: {
			current: 0,
			last: 0
		},
		products: []
	};

	var getPage = function (productName, currentPage, lastPage, callback) {
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

		var url = "/search/products/" + productName + "/page/" + currentPage + "/size/" + pageSize;
		$http.get(url).then(function (response) {
			isLoading = false;
			callback(response.data);
		}, rejectedFn);
	}

	return {
		getPage: getPage
	}
})