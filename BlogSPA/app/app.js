(function () {
    "use strict";
    
    var app = angular.module('app', ['app.dashboard', 'app.blog', 'services.notifications', 'services.blogDatabase']);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //$locationProvider.html5Mode(true);
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);

    app.controller('AppController', ['$scope', 'notifications', 'blogDatabase', function ($scope, notifications, blogDatabase) {
        
        var blog = { id: '123', title: 'Blog Teste', url: 'http://localhost:56271/#/dashboard', imgUrl: 'http://localhost:56271/content/image/glasses.png', posts: [] };

        var promise = blogDatabase.loadPosts();
        console.log(promise);
        promise.then(function (p) {
            blog.posts = p.data;
        });
        
        $scope.blog = blog;

        $scope.notifications = notifications;

        $scope.removeNotification = function (notification) {
            notifications.remove(notification);
        };

        $scope.$on('$routeChangeError', function (event, current, previous, rejection) {
            notifications.pushForCurrentRoute('errors.route.changeError', 'error', {}, { rejection: rejection });
        });
    }]);

}());