
angular.module("AccountModule")
	.controller("AccountCtrl", function ($scope, $http, $location, $window) {
		$scope.getRequestToken = function (socNetwork) {

			var rejectFn = function (response) {
				// add errors
				// call error view
				//$location.path('/Error')
			}

			var accessFn = function (response) {
				$window.location.href = response.data;
			}

			var config = {
				method: "GET",
				url: "/api/Account/SignIn/" + socNetwork
			};

			$http(config).then(accessFn, rejectFn);
		}
	});