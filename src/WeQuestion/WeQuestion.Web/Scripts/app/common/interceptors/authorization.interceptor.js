(function () {
    'use strict';

    angular.module('app')
    .factory('authInterceptor', authInterceptor)
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    function authInterceptor() {
        return {
            request: function (config) {
                var bearerToken = localStorage.getItem('bearerToken');
                if(bearerToken)
                    config.headers.Authorization = 'Bearer ' + bearerToken;
                return config;
            },

            response: function (res) {
                return res;
            }
        }
    }
})();