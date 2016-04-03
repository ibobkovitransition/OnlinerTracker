var repositories = angular.module("OnlinerTracker.Repositories");

repositories.factory("ProductTrackingRepository", function ($log, $localStorage) {

	var getPositionById = function (product) {
		if (!$localStorage.productTracking) {
			return -1;
		}

		for (var i = 0; i < $localStorage.productTracking.length; i++) {
			if (product.id === $localStorage.productTracking[i].id) {
				return i;
			}
		}

		return -1;
	}

	var get = function () {
		return $localStorage.productTracking;
	}

	var add = function (product) {
		$localStorage.productTracking.push(product);
	}

	var remove = function (product) {
		var index = getPositionById(product);
		if (index !== -1) {
			$localStorage.productTracking.splice(index, 1);
		}

		return false;
	}

	var update = function (product) {
		var index = getPositionById(product);
		$localStorage.productTracking[index] = product;
	}

	var addOrUpdate = function (product) {
		var index = getPositionById(product);

		if (index === -1) {
			add(product);
		} else {
			update(product);
		}

		return true;
	}

	return {
		get: get,
		add: add,
		remove: remove,
		update: update,
		addOrUpdate: addOrUpdate
	}
});

repositories.factory("UserInfoRepository", function ($log, $localStorage) {

	var get = function () {
		return $localStorage.userInfo;
	}

	var update = function (userInfo) {
		$localStorage.userInfo = userInfo;
	}

	return {
		get: get,
		update: update
	}
});

repositories.factory("CurrencyRepository", function ($log, $localStorage) {
	var get = function () {
		return $localStorage.currency;
	}

	return {
		get: get
	}
});
