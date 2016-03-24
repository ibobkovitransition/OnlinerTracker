function SearchController($scope, $log, $location, ProductSearchService, ProductUploadService, ProductTrackingService, UserInfoService) {

	// вынести во внешний контроллер
	$scope.searchQuery = "";
	$scope.items = [];
	$scope.page = {
		current: 0,
		last: 0
	};
	$scope.userInfo = UserInfoService.get();

	// вынес логику в сервисы
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
			ProductTrackingService.track(product);
		} else {
			ProductTrackingService.untrack(product);
		}
	}

	$scope.findProducts = function () {
		ProductSearchService.find($scope.searchQuery, loadPage);
	}

	$scope.getCssClass = function (product) {
		return product.is_tracked ?
			"list-group-item-tracked" : product.is_added ? "list-group-item-added" : "";
	}

	$scope.uploadProducts = function () {
		if ($scope.page.current >= $scope.page.last || $scope.page.current === 0) {
			return;
		}

		$scope.page.current++;
		ProductUploadService.getPage($scope.searchQuery, $scope.page.current, $scope.page.last, uploadPage);
	}
};

angular.module("OnlinerTracker.Controllers").controller("SearchController", SearchController);