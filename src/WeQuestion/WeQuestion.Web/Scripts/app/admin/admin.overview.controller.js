(function () {
    'use strict';

    angular.module('app').controller('adminOverviewController', AdminOverviewController);

    AdminOverviewController.$inject = ['$state'];
    function AdminOverviewController($state) {
        console.log(56)
        var vm = this;

        vm.Something = 'hoho';
    }
})();