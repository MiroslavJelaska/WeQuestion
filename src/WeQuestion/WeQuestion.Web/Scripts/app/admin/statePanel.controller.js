(function () {
    'use strict';

    angular.module('app').controller('admin_StatePanelController', Admin_StatePanelController);

    Admin_StatePanelController.$inject = ['$state', 'surveyService', 'surveyState'];
    function Admin_StatePanelController($state, surveyService, surveyState) {
        var vm = this;

        vm.currentState = $state.current.data.currentSurveyState;
        vm.surveyState = surveyState;
        
        surveyService.getAll(vm.currentState)
        .then(function (allsurveys) {
            vm.surveys = allsurveys;
        });
    }
})();