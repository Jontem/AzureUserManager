app.factory('userResource', ['$resource', function ($resource) {
    return $resource('/api/userapi/', { userId: '@id' },
    {
        'update': { method: 'PUT' },
        'find': { method: 'GET', isArray: true, url: '/api/userapi/find' },
    });
}]);