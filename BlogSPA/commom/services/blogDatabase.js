(function (ng) {
    "use strict";
    
    var module = ng.module('services.blogDatabase', []);
    module.factory('blogDatabase', ['$http', '$q', '$timeout', function ($http, $q, $timeout) {
        function loadBlog() {
            //return $http.get('/json/postDTO.json');

            //return $http.get('/api/post');

            var deferred = $q.defer();

            $timeout(function () {
                deferred.resolve({
                    id: "1",
                    title: "Semana da Computação",
                    posts: []
                });
            }, 2000);

            return deferred.promise;
        }

        function loadPosts() {
            //return $http.get('/json/blogDTO.json');
            
            //return $http.get('/api/blog');

            var deferred = $q.defer();

            $timeout(function () {
                deferred.resolve({
                    data:
                        [{ id: '123', author: 'Diego B. Fernandez', title: 'Post 1', text: 'Texto do Post 1', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '124', author: 'Diego B. Fernandez', title: 'Post 2 titulo longo', text: 'Texto do Post 2', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '125', author: 'Diego B. Fernandez', title: 'Post 3', text: 'Texto do Post 3 Texto do Post 3 Texto do Post 3 Texto do Post 3 Texto do Post 3 Texto do Post 3 Texto do Post 3 Texto do Post 4 Texto do Post 5 Texto do Post 6', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        , { id: '126', author: 'Diego B. Fernandez', title: 'Post 4', text: 'Texto do Post 4', publicationDate: '05/05/2013', highlightImage: 'http://fakeimg.pl/222x180/', category: 'Teste' }
                        ]
                });
            }, 2000);

            return deferred.promise;
        }

        function loadPost(postID) {
            
        }

        return {
            loadBlog: loadBlog,
            loadPosts: loadPosts,
            loadPost: loadPost
        };
    }]);

}(angular));