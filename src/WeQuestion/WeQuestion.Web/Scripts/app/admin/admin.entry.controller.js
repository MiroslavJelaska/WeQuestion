(function () {
    'use strict';

    angular.module('app').controller('adminEntryController', adminEntryController);

    adminEntryController.$inject = ['$state'];
    function adminEntryController($state) {
        var vm = this;

        vm.Something = 'hoho';
    }
})();