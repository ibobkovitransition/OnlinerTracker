angular.module("HomeModule")
	.controller("SearchCtrl", function($scope, $http) {
		$scope.searchQuery = null;
		$scope.data = [];
		$scope.page = null;

		var successFn = function(response) {
			console.log(response);
			$scope.page = response.page;
			$scope.data = response.data.Products;
		}

		var rejectFn = function(response) {
			console.log(response);
		}

		$scope.searchRequest = function() {
			if (!$scope.searchQuery) {
				$scope.data = [];
			} else {
				$http.get("/products/" + $scope.searchQuery + "/page/1/size/100").then(successFn, rejectFn);
			}
		}
	});