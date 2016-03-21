angular.module("HomeModule")
	.controller("SearchCtrl", function ($scope, $http, $log) {
		$scope.searchQuery = null;
		$scope.data = [];
		$scope.page = {
			current: 0,
			last: 0,
			totalItems: 0
		};
		$scope.totalItems = 0;

		var searchSuccess = function (response) {
			$log.log("Search success: ", response);
			$scope.data = response.data.products;
			$scope.page = response.data.page;
			$scope.totalItems = response.data.total;
		}

		var searchError = function (response) {
			$log.error("Search error:", response);
		}

		var trackSuccess = function (response) {
			$log.log("Track success: ", response);
		}

		var trackError = function (response) {
			$log.error("Track error: ", response);
		}

		var untrackSuccess = function (response) {
			$log.log("Untrack success: ", response);
		}

		var untrackError = function (response) {
			$log.error("Untrack error: ", response);
		}

		$scope.trackProduct = function (product) {
			var trackUrl = "/tracking/start";
			var untrackUrl = "/tracking/stop";

			if (product.is_tracked) {
				$http.post(trackUrl + "/" + product.id, product).then(trackSuccess, trackError);
			} else {
				$http.put(untrackUrl + "/" + product.id, product).then(untrackSuccess, untrackError);
			}

			product.is_added = true;
		}

		$scope.findProducts = function (page) {
			if (!$scope.searchQuery) {
				$scope.data = [];
			} else {
				var pageNumber = page === 0 ? 1 : page;
				var url = "/search/products/" + $scope.searchQuery + "/page/" + pageNumber;
				$http.get(url).then(searchSuccess, searchError);
			}
		}

		$scope.selectPage = function() {
			var pageNumber = prompt("Total pages: " + $scope.page.last);
			if (!isNaN(pageNumber) && pageNumber > 0 && pageNumber <= $scope.page.last) {
				$scope.page.current = pageNumber;
				$scope.findProducts(pageNumber);
			}
		}
	});