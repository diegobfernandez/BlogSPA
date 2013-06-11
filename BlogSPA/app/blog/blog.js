(function () {
    "use strict";

    var blogModule = angular.module('app.blog', []);

    blogModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: '/app/blog/blog-view.tpl.html', controller: 'BlogController' });
    }]);

    blogModule.controller('BlogController', ['$scope', function ($scope) {}]);
}());