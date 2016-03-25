angular.module("OnlinerTracker.Services")
.factory("ProductTrackingService", function ($http, $log, ProductTrackingRepository, URLS) {

	var trackProduct = function (product) {
		product.is_added = true;
		ProductTrackingRepository.addOrUpdate(product);

		$http.post(URLS.TRACK + "/" + product.id, product).then(function() {
			$log.log("Done (track)");
		}, function(response) {
			$log.error("Error (track) ", response);
		});
	}

	var untrackProduct = function (product) {
		product.is_added = true;
		ProductTrackingRepository.update(product);

		$http.put(URLS.UNTRACK + "/" + product.id).then(function () {
			$log.log("Done (untrack)");
		}, function (response) {
			$log.error("Error (untrack) ", response);
		});
	}

	var removeProduct = function (product) {
		ProductTrackingRepository.remove(product);

		$http.delete(URLS.REMOVE + "/" + product.id).then(function () {
			$log.log("Done (remove)");
		}, function (response) {
			$log.error("Error (remove) ", response);
		});
	}

	var trackIncrease = function (product) {
		ProductTrackingRepository.update(product);

		$http.put(URLS.INCREASE + "/" + product.id, product).then(function () {
			$log.log("Done (TrackIncrease)");
		}, function (response) {
			$log.error("Error (TrackIncrease) ", response);
		});
	}

	var trackDecrease = function (product) {
		ProductTrackingRepository.update(product);

		$http.put(URLS.DECREASE + "/" + product.id, product).then(function () {
			$log.log("Done (TrackDecrease)");
		}, function (response) {
			$log.error("Error (TrackDecrease) ", response);
		});
	}

	var get = function (callback) {
		return ProductTrackingRepository.get();
	}

	return {
		track: trackProduct,
		untrack: untrackProduct,
		remove: removeProduct,
		trackIncrease: trackIncrease,
		trackDecrease: trackDecrease,
		get: get
	}
})