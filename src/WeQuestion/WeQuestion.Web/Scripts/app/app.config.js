(function () {
    'use strict';
    
    angular.module('app').config(AppConfig);

    AppConfig.$inject = ['$urlRouterProvider', '$locationProvider'];
    function AppConfig($urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise('/admin/provisional');
        $locationProvider.html5Mode(true);
    }
})();