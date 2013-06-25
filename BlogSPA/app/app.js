// globals
var webService = {};
webService.url = '/api';

(function () {
    "use strict";
    
    var app = angular.module('app', ['app.blog', 'services.notifications', 'services.blogDB']);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //$locationProvider.html5Mode(true);
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);

    app.controller('AppController', ['$scope', 'notifications', 'blogDB.blog', function ($scope, notifications, blogDB) {
        // $scope declarations
        $scope.blog = {};
        $scope.notifications = notifications;

        $scope.removeNotification = function (notification) {
            notifications.remove(notification);
        };
        $scope.$on('$routeChangeError', function (event, current, previous, rejection) {
            notifications.pushForCurrentRoute('errors.route.changeError', 'error', {}, { rejection: rejection });
        });

        // privates
        function loadBlog() {
            var blogPromise = blogDB.loadBlog();
            blogPromise.success(function (data) {
                $scope.blog = data;
                console.log($scope.blog);
            });
        }

        // Initialization
        loadBlog();
    }]);

}());