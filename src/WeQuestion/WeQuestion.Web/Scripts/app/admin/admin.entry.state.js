(function () {
    'use strict';

    angular.module('app').config(AdminEntryStateConfig);

    AdminEntryStateConfig.$inject = ['$stateProvider'];
    function AdminEntryStateConfig($stateProvider) {
        $stateProvider
        .state('entry', {
            url: '/admin/entry',

            templateUrl: '/Scripts/app/admin/admin.entry.template.html'
        });
    }
})();