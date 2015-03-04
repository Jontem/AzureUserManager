var app = angular.module('AzureUserManager', ['ui.router', 'ngResource', 'ui.bootstrap']);

app.run(['$rootScope', function ($rootScope) {
    $rootScope.$on('$stateChangeSuccess', function (event, to, toParams, from, fromParams) {
        $rootScope.$previousState = from;
    });
}]);

app.config(function($stateProvider, $urlRouterProvider) {
    // For any unmatched url, redirect to /state1
    $urlRouterProvider.otherwise("/list/");

    $stateProvider
        .state('home', {
            abstract: true,
            url: '/',
            template: '<div ui-view>/div>'
        })
            .state('home.list', {
                url: "list/{searchKey}",
                templateUrl: "app/partials/users.html",
                controller: 'listUsersCtrl'
            })

            .state('home.user', {
                url: "user/{userId}",
                templateUrl: "app/partials/userDetails.html",
                controller: 'userDetailsCtrl'
            })

            .state('home.addUser', {
                url: "addUser/",
                templateUrl: "app/partials/addUser.html",
                controller: 'addUserCtrl'
            });

})