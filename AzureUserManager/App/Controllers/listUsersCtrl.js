app.controller('listUsersCtrl',
    ['$scope', '$stateParams', '$resource', '$rootScope', 'userResource', '$state', '$modal',
    function ($scope, $stateParams, $resource, $rootScope, userResource, $state, $modal) {

        $scope.queryResults = userResource.query();

        $scope.$watch(function() {
            return $rootScope.searchKey;
        }, function() {
            $scope.search($rootScope.searchKey);
        });

        $scope.search = function (searchKey) {
            if (searchKey && searchKey.length > 2) {
                $scope.queryResults = userResource.find({ searchKey: searchKey });
                $state.go('home.list', { searchKey: searchKey });
            }
        };

        $scope.delete = function (user, row) {

            var modalInstance = $modal.open({
                templateUrl: 'app/partials/confirmModal.html',
                controller: 'confirmModalCtrl',
                size: 'sm',
                resolve: {
                    customSettings: function() {
                        return {
                            heading: 'Are you sure',
                            body: 'Are you sure you wan\'t to delete this user?'
                        };
                    }
                }
            });

            modalInstance.result.then(function () {
                user.$delete();
                $scope.queryResults.splice(indexOfUser(user, $scope.queryResults), 1);
            }, function () {
            });
            
        };

        function indexOfUser(user, users) {
            var index = -1;
            for (var i = 0; i < users.length; i++) {
                if (user.id == users[i].id) {
                    index = i;
                    break;
                }
            }

            return index;
        }


    }
]);