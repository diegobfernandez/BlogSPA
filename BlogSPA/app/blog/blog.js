(function () {
    "use strict";

    var blogModule = angular.module('app.blog', ['services.blogDatabase']);

    blogModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: '/app/blog/blog-view.tpl.html', controller: 'BlogController' });
    }]);

    blogModule.controller('BlogController', ['$scope', 'blogDatabase', function ($scope, blogDatabase) {
        var postsPromise = blogDatabase.loadPosts();
        postsPromise.then(function (p) {
            $scope.posts = p.data;
        });
    }]);
}());