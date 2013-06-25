(function () {
    "use strict";
    
    var app = angular.module('app', ['app.dashboard', 'app.blog', 'services.notifications', 'services.blogDatabase']);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //$locationProvider.html5Mode(true);
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);

    app.controller('AppController', ['$scope', 'notifications', 'blogDatabase', function ($scope, notifications, blogDatabase) {
        $scope.blog = {};
        $scope.blog.posts = [];

        var blogPromise = blogDatabase.loadBlog();
        blogPromise.then(function (o) {
            $scope.blog = o;
        });
        
        $scope.notifications = notifications;

        $scope.removeNotification = function (notification) {
            notifications.remove(notification);
        };

        $scope.$on('$routeChangeError', function (event, current, previous, rejection) {
            notifications.pushForCurrentRoute('errors.route.changeError', 'error', {}, { rejection: rejection });
        });
    }]);

}());