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
                for (var i=0; i < data.length; i++) {
                    console.log(i);
                    var date = new Date(data[i].publicationDate);

                    var dd = date.getDate();
                    var mm = date.getMonth() + 1; //January is 0!
                    var yyyy = date.getFullYear();

                    if (dd < 10) dd = '0' + dd;
                    if (mm < 10) mm = '0' + mm;

                    data[i].publicationDate = mm + '/' + dd + '/' + yyyy;
                }

                $scope.posts = data;
            });
        }

        // Initialization
        loadPosts();
    }]);

}(angular));