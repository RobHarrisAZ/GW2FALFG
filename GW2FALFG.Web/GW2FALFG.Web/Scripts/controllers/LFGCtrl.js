LFG.controllers.controller('LFGCtrl', ['$scope', '$http', '$routeParams', function($scope, $http, $routeParams) {
    var groupRequestID = $routeParams.id,
        getAllGroupRequests = function() {
            $http.get('/api/group/get').success(function(response) {
                $scope.GroupRequestsAll = response;
            });
        },
        getGroupRequestById = function(id) {
            $http.get('/api/group/' + id).success(function (response) {
                $scope.GroupRequest = response;
            });
        };

}]);