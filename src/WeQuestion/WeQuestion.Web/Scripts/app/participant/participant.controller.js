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
        vm.action = {
            uncheckOtherOptions: uncheckOtherOptions
        }
        
        surveyService.get(surveyId)
        .then(survey => vm.survey = survey);

        function isSuveyOpen() {
            if (vm.survey && vm.survey.closingTimestamp && vm.survey.accessToken)
                return moment(vm.survey.closingTimestamp) > moment();
            return false;
        }

        function uncheckOtherOptions(selectedOption) {
        console.log(selectedOption);
            var question = _.find(vm.survey.questions, function (question) {
                return _.find(question.options, function (option) {
                    return option.$$hashKey === selectedOption.$$hashKey;
                });
            });

            _.each(question.options, function (option) {
                if (option.$$hashKey !== selectedOption.$$hashKey)
                    option.isSelected = false;
            });
        }
    }
})();