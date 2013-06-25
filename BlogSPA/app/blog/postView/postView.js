(function (ng) {
    "use strict";

    var module = ng.module('app.postView', ['services.blogDB']);

    module.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/post/:slug', { templateUrl: '/app/blog/postView/postView.tpl.html', controller: 'PostViewController' });
    }]);

    module.controller('PostViewController', ['$scope', '$routeParams', 'blogDB.post', function ($scope, $routeParams, postDB) {
        var slug = $routeParams.slug;
        
        function loadPost() {
            var promise = postDB.loadPost(slug);
            promise.success(function (data) {
                $scope.post = data;
            });
        }

        loadPost();
    }]);

}(angular));