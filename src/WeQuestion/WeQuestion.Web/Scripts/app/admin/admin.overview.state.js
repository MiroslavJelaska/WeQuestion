(function () {
    'use strict';

    angular.module('app').config(AdminOverviewStateConfig);

    AdminOverviewStateConfig.$inject = ['$stateProvider'];
    function AdminOverviewStateConfig($stateProvider) {
        console.log(2);
        $stateProvider
        .state('overview', {
            url: '/admin/overview',
            data: {
                stateTitle: 'Pregled'
            },
            templateUrl: '/Scripts/app/admin/admin.overview.template.html',
            controller: 'adminOverviewController',
            controllerAs: 'vm'
        });
    }
})();