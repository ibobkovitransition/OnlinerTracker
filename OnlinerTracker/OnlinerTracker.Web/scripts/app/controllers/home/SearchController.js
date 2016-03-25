function SearchController(
	$scope,
	$location,
	$anchorScroll,
	AuthService,
	ProductSearchService,
	ProductUploadService,
	ProductTrackingService,
	UserInfoService,
	CurrencyService,
	ROUTES) {

	$scope.filterQuery = "";
	$scope.currency = CurrencyService.get();
	$scope.items = [];
	$scope.userInfo = UserInfoService.get();
	$scope.page = {
		current: 0,
		last: 0
	};

	var loadPage = function (data) {
		$scope.items = data.products;
		$scope.page = data.page;
	}

	var uploadPage = function (data) {
		Array.prototype.push.apply($scope.items, data.products);
	}

	$scope.logout = function () {
		$location.path(ROUTES.AUTH);
		AuthService.logout();
	}

	$scope.anchorTop = function (id) {
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