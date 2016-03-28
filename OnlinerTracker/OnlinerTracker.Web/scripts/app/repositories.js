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

	var clone = function (product) {
		var result = {};
		angular.copy(product, result);
		return result;
	}

	var get = function () {
		if (!$localStorage.productTracking) {
			return [];
		}

		var result = [];
		angular.copy($localStorage.productTracking, result);
		return result;
	}

	var add = function (product) {
		if (!$localStorage.productTracking) {
			return false;
		}

		$localStorage.productTracking.push(clone(product));
		return true;
	}

	var remove = function (product) {
		if (!$localStorage.productTracking) {
			return false;
		}

		var index = getPositionById(product);
		if (index !== -1) {
			$localStorage.productTracking.splice(index, 1);
			return true;
		}

		return false;
	}

	var update = function (product) {
		if (!$localStorage.productTracking) {
			return false;
		}

		var cloned = clone(product);
		var index = getPositionById(cloned);
		$localStorage.productTracking[index] = cloned;

		return true;
	}

	var addOrUpdate = function (product) {
		if (!$localStorage.productTracking) {
			return false;
		}

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

	var emptyResult = {
		id: "",
		first_name: "",
		email: "",
		settings: {
			prefered_time: "",
			selected_currency: ""
		}
	};

	var clone = function (userInfo) {
		var result = {};
		angular.copy(userInfo, result);
		return result;
	}

	var get = function () {
		if (!$localStorage.userInfo) {
			return clone(emptyResult);
		}

		return clone($localStorage.userInfo);
	}

	var update = function (userInfo) {
		if (!$localStorage.userInfo) {
			return false;
		}

		$localStorage.userInfo = clone(userInfo);
		return true;
	}

	return {
		get: get,
		update: update
	}
});

repositories.factory("CurrencyRepository", function ($log, $localStorage) {

	var clone = function (currency) {
		var result = [];
		angular.copy(currency, result);
		return result;
	}

	var get = function () {
		if (!$localStorage.currency) {
			return [];
		}

		return clone($localStorage.currency);
	}

	return {
		get: get
	}
});
