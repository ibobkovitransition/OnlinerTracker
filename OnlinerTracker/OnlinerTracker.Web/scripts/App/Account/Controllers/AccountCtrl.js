angular.module("AccountModule")
	.controller("AccountCtrl", function ($scope, $http, $location, $window) {
		$scope.getRequestUrl = function (socNetwork) {
			var rejectFn = function (response) {
				//console.log('Bad', response);
				// add errors
				// call error view
				//$location.path('/Error')
			}

			var accessFn = function (response) {
				$window.location.href = response.data;
			}

			$http.get("/signin/" + socNetwork).then(accessFn, rejectFn);
		}
	});