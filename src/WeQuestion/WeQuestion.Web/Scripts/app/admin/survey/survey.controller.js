(function () {
    'use strict';

    angular.module('app').controller('adminSurveyController', adminSurveyController);

    adminSurveyController.$inject = ['$state', '$stateParams', 'surveyService', 'authorizationService'];
    function adminSurveyController($state, $stateParams, surveyService, authorizationService) {
        var vm = this;


        const surveyId = $stateParams.id;
        vm.check = {
            isSuveyOpen: isSuveyOpen
        }

        surveyService.get(surveyId)
        .then(survey => vm.survey = survey);

        function isSuveyOpen() {
            if (vm.survey && vm.survey.closingTimestamp && vm.survey.accessToken)
                return vm.survey.closingTimestamp > new Date();
            return false;
        }
    }
})();