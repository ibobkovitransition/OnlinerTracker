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
		if (!$localStorage.productTracking) {
			return [];
		}

		//var result = [];
		//angular.copy($localStorage.productTracking, result);
		return $localStorage.productTracking;
	}

	var add = function (product) {
		if (!$localStorage.productTracking) {
			return false;
		}

		$localStorage.productTracking.push(product);
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

		var index = getPositionById(product);
		$localStorage.productTracking[index] = product;

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
		id: null,
		first_name: "",
		email: null,
		settings: {
			prefered_time: null,
			selected_currency: null
		}
	};

	var get = function () {
		if (!$localStorage.userInfo) {
			// TODO: clone
			return emptyResult;
		}

		return $localStorage.userInfo;
	}

	var update = function (userInfo) {
		if (!$localStorage.userInfo) {
			return false;
		}

		$localStorage.userInfo = userInfo;
		return true;
	}

	return {
		get: get,
		update: update
	}
});

repositories.factory("CurrencyRepository", function ($log, $localStorage) {

	var get = function () {
		if (!$localStorage.currency) {
			return [];
		}

		return $localStorage.currency;
	}

	return {
		get: get
	}
});
