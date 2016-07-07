(function () {
    'use strict';

    angular.module('app').controller('adminCreateController', adminCreateController);

    adminCreateController.$inject = ['$state'];
    function adminCreateController($state) {
        var vm = this;

        vm.Something = 'Stvori novi';
    }
})();