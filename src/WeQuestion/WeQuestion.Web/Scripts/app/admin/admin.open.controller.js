(function () {
    'use strict';

    angular.module('app').controller('adminOpenController', Admin_OpenController);

    Admin_OpenController.$inject =['$state', 'surveyService', 'surveyState'];
    function Admin_OpenController($state, surveyService, surveyState) {
        var vm = this;

        surveyService.getAll(surveyState.Open)
        .then(function (allsurveys) {
            vm.surveys = allsurveys;
            console.log(vm.surveys);
        });
    }
})();