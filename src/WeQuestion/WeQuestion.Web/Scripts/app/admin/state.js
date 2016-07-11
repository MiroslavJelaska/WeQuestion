(function () {
    'use strict';

    angular.module('app').config(AdminStateConfig);

    AdminStateConfig.$inject = ['$stateProvider'];
    function AdminStateConfig($stateProvider) {
        $stateProvider
        .state('admin', {
            url: '/admin',
            abstract: true,
            template: '<div ui-view="menu"></div><div ui-view="content"></div>'
        });
    }
})();