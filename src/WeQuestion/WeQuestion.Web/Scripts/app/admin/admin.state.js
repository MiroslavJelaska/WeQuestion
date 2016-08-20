(function () {
    'use strict';

    angular.module('app').config(AdminStateConfig);

    AdminStateConfig.$inject = ['$stateProvider'];
    function AdminStateConfig($stateProvider) {
        $stateProvider
        .state('admin', {
            url: '/admin',
            abstract: true,
            onEnter: function ($state, authorizationService, roleType) {
                var authDetails = authorizationService.getAuthDetails();
                console.log(roleType.Anonymous, authDetails)
                if (!authDetails)
                    $state.go('login');
                if (authDetails.role == roleType.Anonymous) {
                    $state.go('login');
                }
            }
        });
    }
})();