(function () {
    "use strict";
    
    var app = angular.module('app', ['ui.bootstrap', 'app.dashboard', 'app.blog', 'services.notifications']);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //$locationProvider.html5Mode(true);
        $routeProvider.otherwise({ redirectTo: '/dashboard' });
    }]);

    app.controller('AppController', ['$scope', 'notifications', function($scope, notifications) {
        $scope.notifications = notifications;

        $scope.removeNotification = function (notification) {
            notifications.remove(notification);
        };

        $scope.$on('$routeChangeError', function (event, current, previous, rejection) {
            notifications.pushForCurrentRoute('errors.route.changeError', 'error', {}, { rejection: rejection });
        });
    }]);

}());