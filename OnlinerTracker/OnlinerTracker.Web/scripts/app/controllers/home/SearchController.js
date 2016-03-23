function SearchController($scope, $log, $location, productSearch, productUpload, productTracking) {

	// вынести во внешний контроллер
	$scope.searchQuery = "";
	$scope.items = [];
	$scope.page = {
		current: 0,
		last: 0
	};

	// вынес бизнесс логику в сервисы
	// https://github.com/mgechev/angularjs-style-guide/blob/master/README-ru-ru.md

	var loadPage = function (data) {
		$scope.items = data.products;
		$scope.page = data.page;
	}

	var uploadPage = function (data) {
		Array.prototype.push.apply($scope.items, data.products);
	}

	$scope.toAdmin = function () {
		$location.path("/Admin");
	}

	$scope.trackProduct = function (product) {
		if (product.is_tracked) {
			productTracking.track(product);
		} else {
			productTracking.untrack(product);
		}
	}

	$scope.findProducts = function () {
		productSearch.find($scope.searchQuery, loadPage);
	}

	$scope.getCssClass = function (product) {
		return product.is_tracked ?
			"list-group-item-tracked" : product.is_added ? "list-group-item-added" : "";
	}

	$scope.getNewProducts = function () {
		console.log("GET NEW PRODUCTS");
		if ($scope.page.current >= $scope.page.last || $scope.page.current === 0) {
			$log.info("Nothing to upload");
			return;
		}

		$scope.page.current++;
		productUpload.getPage($scope.searchQuery, $scope.page.current, $scope.page.last, uploadPage);
	}

};

angular.module("home").controller("SearchController", SearchController);