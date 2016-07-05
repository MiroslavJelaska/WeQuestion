(function () {
    'use strict';

    angular.module('app').config(AdminEntryStateConfig);

    AdminEntryStateConfig.$inject = ['$stateProvider'];
    function AdminEntryStateConfig($stateProvider) {
        console.log(2);
        $stateProvider
        .state('entry', {
            url: '/admin/entry',

            templateUrl: '/Scripts/app/admin/admin.entry.template.html'
        });
    }
})();