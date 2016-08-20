(function () {
    'use strict';

    angular.module('app').controller('LoginController', LoginController);

    LoginController.$inject = ['$state', 'authorizationService'];
    function LoginController($state, authorizationService) {
        var vm = this;
        vm.authDetails = authorizationService.getAuthDetails();
        vm.action = {
            login: login,
            logout: logout
        }

        function login(email, password) {
            authorizationService.login(email, password)
            .then(function () {
                $state.go('admin.open');
            });
        }
        function logout() {
            authorizationService.logout();
            window.location.reload();
        }
    }
})();