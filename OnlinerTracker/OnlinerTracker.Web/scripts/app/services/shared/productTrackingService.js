angular.module("OnlinerTracker.Services")
.factory("ProductTrackingService", function ($http, $log, ProductTrackingRepository) {

	var trackUrl = "/tracking/start";
	var untrackUrl = "/tracking/stop";
	var removeUrl = "/tracking/remove";

	var increaseUrl = "/tracking/increase";
	var decreaseUrl = "/tracking/decrease";

	var trackProduct = function (product) {
		product.is_added = true;
		ProductTrackingRepository.addOrUpdate(product);

		$http.post(trackUrl + "/" + product.id, product).then(function() {
			$log.log("Done (track)");
		}, function(response) {
			$log.error("Error (track) ", response);
		});
	}

	var untrackProduct = function (product) {
		product.is_added = true;
		ProductTrackingRepository.update(product);

		$http.put(untrackUrl + "/" + product.id).then(function () {
			$log.log("Done (untrack)");
		}, function (response) {
			$log.error("Error (untrack) ", response);
		});
	}

	var removeProduct = function (product) {
		ProductTrackingRepository.remove(product);

		$http.delete(removeUrl + "/" + product.id).then(function () {
			$log.log("Done (remove)");
		}, function (response) {
			$log.error("Error (remove) ", response);
		});
	}

	var trackIncrease = function (product) {
		ProductTrackingRepository.update(product);

		$http.put(increaseUrl + "/" + product.id, product).then(function () {
			$log.log("Done (TrackIncrease)");
		}, function (response) {
			$log.error("Error (TrackIncrease) ", response);
		});
	}

	var trackDecrease = function (product) {
		ProductTrackingRepository.update(product);

		$http.put(decreaseUrl + "/" + product.id, product).then(function () {
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