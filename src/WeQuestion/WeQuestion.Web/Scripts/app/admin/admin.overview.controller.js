(function () {
    'use strict';

    angular.module('app').controller('adminOverviewController', AdminOverviewController);

    AdminOverviewController.$inject = ['$state', 'surveyService'];
    function AdminOverviewController($state, surveyService) {
        var vm = this;

        surveyService.getAll()
        .then(function (allsurveys) {
            vm.surveys = allsurveys;
            console.log(vm.surveys);
        });
    }
})();