(function() {
    'use strict';

    angular.module('app').controller('adminResultsController', adminResultsController);

    adminResultsController.$inject = ['$state', '$stateParams', 'surveyService'];
    function adminResultsController($state, $stateParams, surveyService) {
        var vm = this;

        const surveyId = $stateParams.id;
        vm.labels = ['Corrent', 'wrong', 'Unanswered'];
        vm.colors = ['#8cbd3f', '#FF2151', '#404040'];
        surveyService.getResult(surveyId)
        .then(result => {
            console.log(1);
            result.questionsWithResults = _.map(result.questionsWithResults, function (questionsWithResults) {
                questionsWithResults.data = [
                    questionsWithResults.correntAnswersCount,
                    questionsWithResults.wrongAnswerCount,
                    questionsWithResults.leftUnansweredCount
                ];
                return questionsWithResults;
            });
            console.log(result.questionsWithResults);

            vm.result = result;
            console.log(result)
        });
    }
})();