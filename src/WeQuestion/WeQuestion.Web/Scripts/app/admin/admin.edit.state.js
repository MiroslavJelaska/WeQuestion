(function () {
    'use strict';

    angular.module('app').config(AdminEditStateConfig);

    AdminEditStateConfig.$inject = ['$stateProvider'];
    function AdminEditStateConfig($stateProvider) {
        $stateProvider
        .state('admin.edit', {
            url: '/edit/:id',
            templateUrl: '/Scripts/app/admin/admin.edit.template.html',
            controller: 'adminEditController',
            controllerAs: 'vm'
        });
    }
})();