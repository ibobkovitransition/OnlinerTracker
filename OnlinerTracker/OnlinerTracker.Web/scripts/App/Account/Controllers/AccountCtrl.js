
angular.module("AccountModule")
	.controller("AccountCtrl", function ($scope, $http, $location, $window) {
		$scope.getRequestToken = function (socNetwork) {
			var rejectFn = function (response) {
				//console.log('Bad', response);
				// add errors
				// call error view
				//$location.path('/Error')
			}

			var accessFn = function (response) {
				$window.location.href = response.data;
			}

			console.log("/api/v1/account/signIn/" + socNetwork);

			var config = {
				method: "GET",
				url: "/api/v1/account/signIn/" + socNetwork
			};

			$http(config).then(accessFn, rejectFn);
		}
	});