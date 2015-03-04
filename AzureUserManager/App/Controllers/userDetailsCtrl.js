app.controller('userDetailsCtrl',
    ['$scope', '$stateParams','userResource','$state',
    function ($scope, $stateParams, userResource, $state) {
        $scope.showSpinner = false;
        $scope.user = userResource.get({ userId: $stateParams.userId });

        $scope.goBack = function () {
            $state.go('^.list');
        };

        $scope.submit = function () {
            $scope.showSpinner = true;
            userResource.update({}, $scope.user, function() {
                $state.go('^.list');
                $scope.showSpinner = false;
            }, function(error) {
                $scope.showSpinner = false;
                console.log(error);
            });
        };
    }
]);