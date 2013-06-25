(function (ng) {
    "use strict";

    var blogModule = ng.module('app.blog', ['services.blogDB']);

    blogModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: '/app/blog/blog-view.tpl.html', controller: 'BlogController' });
    }]);

    blogModule.controller('BlogController', ['$scope', 'blogDB.post', function ($scope, blogDB) {
        // $scope declarations
        $scope.posts = [];

        // privates
        function loadPosts() {
            var postsPromise = blogDB.loadPosts();
            postsPromise.success(function (data) {
                $scope.posts = data;
            });
        }

        // Initialization
        loadPosts();
    }]);
}(angular));