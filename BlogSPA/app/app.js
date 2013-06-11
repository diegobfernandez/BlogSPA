(function () {
    "use strict";
    
    var app = angular.module('app', ['app.dashboard', 'app.blog', 'services.notifications']);

    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //$locationProvider.html5Mode(true);
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);

    app.controller('AppController', ['$scope', 'notifications', function ($scope, notifications) {
        var blog = { id: '123', title: 'Blog Teste', url: 'http://localhost:56271/#/dashboard', imgUrl: 'http://localhost:56271/content/image/glasses.png', posts: [] };
        blog.posts.push({ id: '123', author: '321', title: 'Post 1', text: 'Texto do Post 1', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste'});
        blog.posts.push({ id: '124', author: '321', title: 'Post 2', text: 'Texto do Post 2', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste'});
        blog.posts.push({ id: '125', author: '321', title: 'Post 3', text: 'Texto do Post 3', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste'});
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
        blog.posts.push({ id: '126', author: '321', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' });
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