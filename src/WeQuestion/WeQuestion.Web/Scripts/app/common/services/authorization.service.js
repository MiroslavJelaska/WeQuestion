(function () {
    'use strict';

    angular.module('app').service('authorizationService', authorizationService);

    authorizationService.$inject = ['$http'];
    function authorizationService($http) {
        function login(email, password) {
            return $http.post('/api/auth/login', { email: email, password: password })
            .then(function (response) {
                localStorage.setItem('bearerToken', response.data);
                var decoded = jwt_decode(response.data);
                localStorage.setItem('authDetails', JSON.stringify(decoded));
            });
        }

        function logout() {
            localStorage.removeItem('bearerToken');
            localStorage.removeItem('authDetails');
        }

        function isAuthenticated() {
            return !!localStorage.getItem('bearerToken');
        }

        function getAuthDetails() {
            return JSON.parse(localStorage.getItem('authDetails'));
        }

        return {
            login: login,
            logout: logout,
            isAuthenticated: isAuthenticated,
            getAuthDetails: getAuthDetails
        };
    }
})();