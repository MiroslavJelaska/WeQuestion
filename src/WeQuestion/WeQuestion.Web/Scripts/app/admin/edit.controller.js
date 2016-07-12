(function() {
    'use strict';

    angular.module('app').controller('adminEditController', adminEditController);

    adminEditController.$inject = ['$state', '$stateParams', 'surveyService'];

    function adminEditController($state, $stateParams, surveyService) {
        var vm = this;
        const surveyId = $stateParams.id;

        vm.submitting = false;

        vm.action = {
            submit:              submit,
            addQuestion:         addQuestion,
            addOption:           addOption,
            uncheckOtherOptions: uncheckOtherOptions
        };

        vm.treeOptions = {
            accept: function (sourceNodeScope, destNodesScope, destIndex) {
                return destNodesScope.isParent(sourceNodeScope);
            }
        }

        function submit() {
            vm.saveInProgress = true;
            surveyService.update(vm.newSurvey)
            .then(x => {
                 console.log(x);
                 vm.saveInProgress = false;
            });
        }

        function addQuestion() {
            vm.newSurvey.questions.push({});
        }

        function addOption(question) {
            question.options = question.options || [];
            question.options.push({});
        }

        function uncheckOtherOptions(correctAnswerOption) {
            var question = _.find(vm.newSurvey.questions, function(question) {
                return _.find(question.options, function(option) {
                    return option.$$hashKey === correctAnswerOption.$$hashKey;
                });
            });

            _.each(question.options, function (option) {
                if (option.$$hashKey !== correctAnswerOption.$$hashKey)
                    option.isCorrect = false;
            });
        }

        (function init() {
            surveyService.get(surveyId)
            .then(function (survey) {
                console.log(survey);
                vm.newSurvey = survey;
            });
        })();
    }
})();