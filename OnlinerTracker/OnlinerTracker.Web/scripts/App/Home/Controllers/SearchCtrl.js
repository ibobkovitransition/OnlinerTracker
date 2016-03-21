angular.module("HomeModule")
	.controller("SearchCtrl", function ($scope, $http, $log, $window) {
		$scope.searchQuery = null;
		$scope.data = [];

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

		$scope.findProducts = function () {
			if (!$scope.searchQuery) {
				$scope.data = [];
			} else {
				var pageNumber = 1;
				var pageSize = 25;
				var url = "/search/products/" + $scope.searchQuery + "/page/" + pageNumber + "/size/" + pageSize;
				$http.get(url).then(searchSuccess, searchError);
			}
		}

		$scope.getCssClass = function (product) {
			return product.is_tracked ?
				"list-group-item-tracked" : product.is_added ? "list-group-item-added" : "";
		}
	});