(function () {
    'use strict';

    angular.module('app').config(AdminClosedStateConfig);

    AdminClosedStateConfig.$inject = ['$stateProvider'];
    function AdminClosedStateConfig($stateProvider) {
        $stateProvider
        .state('admin.closed', {
            url: '/closed',
            templateUrl: '/Scripts/app/admin/admin.closed.template.html',
            controller: 'adminClosedController',
            controllerAs: 'vm'
        });
    }
})();