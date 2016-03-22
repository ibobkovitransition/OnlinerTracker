angular.module("home")
.factory("productTracking", function ($http, $log) {

	var trackUrl = "/tracking/start";
	var untrackUrl = "/tracking/stop";
	var removeUrl = "/tracking/remove";

	var trackProduct = function (product) {
		product.is_added = true;
		$http.post(trackUrl + "/" + product.id, product).then(function () { $log.log("Done (track)") }, function (response) { $log.error("Error (track) ", response) });
	}

	var untrackProduct = function (product) {
		$http.put(untrackUrl + "/" + product.id, product).then(function () { $log.log("Done (untrack)") }, function (response) { $log.error("Error (untrack) ", response) });
	}

	var removeProduct = function (product) {
		$http.delete(removeUrl + "/" + product.id).then(function () { $log.log("Done (remove)") }, function (response) { $log.error("Error (remove) ", response) });
	}

	return {
		track: trackProduct,
		untrack: untrackProduct,
		remove: removeProduct
	}
})