(function () {
    "use strict";

    var dashboard = angular.module('app.dashboard', []);

    dashboard.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/dashboard', { templateUrl: '/app/dashboard/dashboard.tpl.html', controller: 'DashboardController' });
    }]);

    dashboard.controller('DashboardController', ['$scope', function ($scope) {
        $scope.title = 'Dashboard';
    }]);

}());