app.controller('confirmModalCtrl',
[
            '$scope', '$modalInstance', 'customSettings',
    function ($scope, $modalInstance, customSettings) {

        angular.extend($scope, customSettings);

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

    }
]);