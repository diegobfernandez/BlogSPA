(function (ng) {
    "use strict";
    
    var module = ng.module('services.blogDB', []);

    module.factory('blogDB.blog', ['$http', '$q', '$timeout', function ($http, $q, $timeout) {
        var resourcePath = webService.url + '/blog';

        function loadBlog() {
            return $http.get(resourcePath);
        }

        return {
            loadBlog: loadBlog
        };
    }]);

    module.factory('blogDB.post', ['$http', '$q', '$timeout', function ($http, $q, $timeout) {
        var resourcePath = webService.url + '/post';

        function loadPosts() {
            return $http.get(resourcePath);
        }

        function loadPost(postID) {
            return $http.get(resourcePath + '/' + postID);
        }

        function createPost(post) {
            return $http.post(resourcePath, post);
        }

        return {
            loadPosts: loadPosts,
            loadPost: loadPost,
            createPost: createPost
        };
    }]);

}(angular));