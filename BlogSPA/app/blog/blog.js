(function () {
    "use strict";

    var blogModule = angular.module('app.blog', []);

    blogModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/blog/:name', { templateUrl: '/app/blog/blog-view.tpl.html', controller: 'BlogController' });
    }]);

    blogModule.controller('BlogController', ['$scope', function ($scope) {
        var blog = { ID:'123', Title: 'Blog Teste', Posts: [] };
        blog.Posts.push({ ID: '123', BlogID: '123', AuthorID: '321', Title: 'Post 1', Text: 'Texto do Post 1', CreationDate: '05/05/2013', PublicationDate: '05/05/2013', HighlightImage: null, Draft: false });
        $scope.blog = blog;
    }]);

}());