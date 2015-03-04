app.controller('addUserCtrl',
    ['$scope', '$stateParams', 'userResource', '$state',
    function ($scope, $stateParams, userResource, $state) {
        $scope.user = {};
        $scope.showSpinner = false;

        $scope.goBack = function () {
            $state.go('^.list');
        };

        $scope.submit = function () {
            $scope.showSpinner = true;
            userResource.save({}, $scope.user, function () {
                $state.go('^.list');
                $scope.showSpinner = false;
            }, function (error) {
                $scope.showSpinner = false;
                console.log(error);
            });
        };
    }
    ]);