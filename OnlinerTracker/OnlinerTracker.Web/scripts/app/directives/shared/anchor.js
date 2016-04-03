angular.module("OnlinerTracker.Directives")
	.directive("anchor", function ($location, $anchorScroll, $window) {
		return {
			link: function ($scope, element, attributes) {
				var target = attributes.target;
				var showAfter = !attributes.showAfter ? 125 : parseInt(attributes.showAfter);

				$scope.isHidden = true;
				$scope.classes = attributes.class;
				$window = angular.element($window);
				element.hide();

				if (!angular.isString(target)) {
					throw Exception("");
				}

				$scope.moveToTarget = function () {
					$location.hash(target);
					$anchorScroll();

					// убираю баг с добавлением # в url
					$location.hash("");
				}

				$window.on("scroll", function () {
					if ($window.scrollTop() > showAfter) {
						element.show();
					} else {
						element.hide();
					}
				});

			},

			restrict: "A",

			replace: true,

			template: function (element, attributes) {
				var result = [
					"<div ng-class='{{classes}}'>",
						"<a ng-click='moveToTarget()'>",
							"<b class='glyphicon glyphicon-arrow-up'>",
							"</b>",
						"</a>",
					"</div>"
				];

				return result.join("");
			}
		}
	});