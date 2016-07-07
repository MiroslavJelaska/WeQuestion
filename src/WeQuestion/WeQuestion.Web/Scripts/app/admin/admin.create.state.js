(function () {
    'use strict';

    angular.module('app').config(AdminCreateStateConfig);

    AdminCreateStateConfig.$inject = ['$stateProvider'];
    function AdminCreateStateConfig($stateProvider) {
        $stateProvider
        .state('admin.create', {
            url: '/admin/create',

            templateUrl: '/Scripts/app/admin/admin.create.template.html'
        });
    }
})();