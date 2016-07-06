(function () {
    'use strict';

    angular.module('app').controller('adminOverviewController', Admin_ProvisionalController);

    Admin_ProvisionalController.$inject =['$state', 'surveyService', 'surveyState'];
    function Admin_ProvisionalController($state, surveyService, surveyState) {
        var vm = this;

        surveyService.getAll(surveyState.Provisional)
        .then(function (allsurveys) {
            vm.surveys = allsurveys;
            console.log(vm.surveys);
        });
    }
})();