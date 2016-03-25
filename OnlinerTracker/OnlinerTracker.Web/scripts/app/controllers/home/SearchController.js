function SearchController($scope, $log, $window, $location, $anchorScroll, ProductSearchService, ProductUploadService, ProductTrackingService, UserInfoService, CurrencyService, ROUTES) {


	// если будет время, то сделать https://github.com/angular-ui/ui-router
	// TODO:
	// дать одинаковое с аналогичным полем в ManageController
	// и строку поиска\фильтрации вынести в директиву
	$scope.filterQuery = "";
	$scope.currency = CurrencyService.get();
	$scope.items = [];
	$scope.userInfo = UserInfoService.get();
	$scope.page = {
		current: 0,
		last: 0
	};

	// вынес логику в сервисы
	// https://github.com/mgechev/angularjs-style-guide/blob/master/README-ru-ru.md

	var loadPage = function (data) {
		$scope.items = data.products;
		$scope.page = data.page;
		console.log($scope.page);
	}

	var uploadPage = function (data) {
		Array.prototype.push.apply($scope.items, data.products);
	}

	$scope.anchorTop = function(id) {
		$location.hash(id);
		$anchorScroll();
	}

	$scope.toAdmin = function () {
		$location.path(ROUTES.ADMIN);
	}

	$scope.trackProduct = function (product) {
		if (product.is_tracked) {
			ProductTrackingService.track(product);
		} else {
			ProductTrackingService.untrack(product);
		}
	}

	$scope.findProducts = function () {
		ProductSearchService.find($scope.filterQuery, loadPage);
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
		ProductUploadService.getPage($scope.filterQuery, $scope.page.current, $scope.page.last, uploadPage);
	}
};

angular.module("OnlinerTracker.Controllers").controller("SearchController", SearchController);