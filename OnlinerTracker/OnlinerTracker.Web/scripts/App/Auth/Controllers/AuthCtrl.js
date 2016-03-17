
angular.module("AuthModule")
	.controller("AuthCtrl", function ($scope, $http, $location, $window) {
		$scope.getAuthUrl = function (socialNetworkName) {

			var rejectFn = function (response) {
				// add errors
				// call error view
				//$location.path('/Error')
			}

			var accessFn = function (response) {
				console.log("accessfn: ", response);

				$window.location.href = response.data;
			}

			var config = {
				method: "GET",
				url: "/api/account/" + socialNetworkName
			};

			$http(config).then(accessFn, rejectFn);
		}
	});