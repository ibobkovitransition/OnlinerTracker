angular.module("OnlinerTracker.Services")
.factory("AlertService", function ($log, $timeout) {

	var createHtml = function(content) {
		var template = [
			"<div class='alert alert-info fixed-alert'>",
				"<strong>",
					content,
				"</strong>",
			"</div>"
		];

		return template.join("");
	}

	var show = function (content, duration) {
		var instance = angular.element(createHtml(content));
		angular.element("body").append(instance);

		$timeout(function () {
			instance.remove();
		}, duration);
	}

	return {
		showAlert: show
	}
});