(function () {
    'use strict';

    angular.module('app').config(Admin_OpenStateConfig);

    Admin_OpenStateConfig.$inject = ['$stateProvider'];
    function Admin_OpenStateConfig($stateProvider) {
        $stateProvider
        .state('admin.open', {
            url: '/open',
            data: {
                stateTitle: 'Pregled'
            },
            templateUrl: '/Scripts/app/admin/admin.provisional.template.html',
            controller: 'adminOpenController',
            controllerAs: 'vm'
        });
    }
})();