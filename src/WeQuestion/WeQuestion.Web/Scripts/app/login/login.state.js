(function () {
    'use strict';

    angular.module('app').config(LoginStateConfig);

    LoginStateConfig.$inject = ['$stateProvider'];
    function LoginStateConfig($stateProvider) {
        $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: '/Scripts/App/login/login.template.html',
            controller: 'LoginController',
            controllerAs: 'vm',
            onEnter: function ($state, authorizationService, roleType) {
                var authDetails = authorizationService.getAuthDetails();
                console.log(1, authDetails)
                if (authDetails) {
                    if (authDetails.role == roleType.Admin)
                        $state.go('admin.open');
                }
            }
        });
    }
})();