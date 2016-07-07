(function () {
    'use strict';

    angular.module('app').controller('adminClosedController', adminClosedController);

    adminClosedController.$inject = ['$state', 'surveyService', 'surveyState'];
    function adminClosedController($state, surveyService, surveyState) {
        var vm = this;

        surveyService.getAll(surveyState.Closed)
        .then(function (allsurveys) {
            vm.surveys = allsurveys;
            console.log(allsurveys);
        });
    }
})();