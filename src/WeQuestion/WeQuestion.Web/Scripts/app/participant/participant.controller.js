(function () {
    'use strict';

    angular.module('app').controller('ParticipantController', ParticipantController);

    ParticipantController.$inject = ['$state', '$stateParams', 'surveyService'];
    function ParticipantController($state, $stateParams, surveyService) {
        var vm = this;

        const surveyId = $stateParams.id;
        vm.check = {
            isSuveyOpen: isSuveyOpen
        }
        
        surveyService.get(surveyId)
        .then(survey => vm.survey = survey);

        function isSuveyOpen() {
            if (vm.survey && vm.survey.closingTimestamp && vm.survey.accessToken)
                return moment(vm.survey.closingTimestamp) > moment();
            return false;
        }
    }
})();