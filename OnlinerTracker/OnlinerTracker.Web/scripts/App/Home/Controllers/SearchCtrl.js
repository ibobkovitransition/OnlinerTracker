var homeModule = angular.module("HomeModule");

homeModule.controller("SearchCtrl", function ($scope, $http, $log, $window) {

	// вынести в модель
	$scope.searchQuery = "";

	$scope.items = [];

	$scope.page = {
		current: 0,
		last: 0
	};

	var searchSuccess = function (response) {
		$log.log("Search success: ", response);
		$scope.items = response.data.products;
		$scope.page = response.data.page;
	}

	$scope.trackProduct = function (product) {
		var trackUrl = "/tracking/start";
		var untrackUrl = "/tracking/stop";
		product.is_added = true;

		if (product.is_tracked) {
			$http.post(trackUrl + "/" + product.id, product);
		} else {
			$http.put(untrackUrl + "/" + product.id, product);
		}
	}

	$scope.findProducts = function () {
		if (!$scope.searchQuery) {
			$scope.data = [];
		} else {
			var pageNumber = 1;
			var pageSize = 25;
			var url = "/search/products/" + $scope.searchQuery + "/page/" + pageNumber + "/size/" + pageSize;
			$http.get(url).then(searchSuccess, function (reponse) { $log.log("Search rejected ", reponse) });
		}
	}

	$scope.getCssClass = function (product) {
		return product.is_tracked ?
			"list-group-item-tracked" : product.is_added ? "list-group-item-added" : "";
	}

	// отдельный модуль
	$scope.isLoading = false;

	$scope.uploadPage = function () {

		if ($scope.page.current >= $scope.page.last || $scope.page.current === 0) {
			return;
		}

		$scope.isLoading = true;

		$scope.page.current++;
		var pageSize = 25;
		var url = "/search/products/" + $scope.searchQuery + "/page/" + $scope.page.current + "/size/" + pageSize;
		$http.get(url).then(function (response) {

			$log.log("success", response);
			// заметстиь concato'm или похожим
			for (var i = 0; i < response.data.products.length; i++) {
				$scope.items.push(response.data.products[i]);
			}

			$scope.isLoading = false;
		}, function (response) {
			console.log("bad ", response);
			$scope.isLoading = false;
		});

	}

	// плагин для скролинга
	// https://sroze.github.io/ngInfiniteScroll/
	// организация файлов  
	// https://habrahabr.ru/post/180837/
	// https://github.com/mgechev/angularjs-style-guide/blob/master/README-ru-ru.md
});