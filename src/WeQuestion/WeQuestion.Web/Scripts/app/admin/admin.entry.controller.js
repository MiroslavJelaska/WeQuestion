(function () {
    'use strict';

    angular.module('app').controller('adminEntryController', adminEntryController);

    adminEntryController.$inject = ['$state'];
    function adminEntryController($state) {
        console.log(256225)
        var vm = this;

        vm.Something = 'hoho';
    }
})();