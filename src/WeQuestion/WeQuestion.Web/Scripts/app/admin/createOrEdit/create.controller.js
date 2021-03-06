﻿(function() {
    'use strict';

    angular.module('app').controller('adminCreateController', adminCreateController);

    adminCreateController.$inject = ['$state', 'surveyService'];

    function adminCreateController($state, surveyService) {
        var vm = this;

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
            surveyService.create(vm.newSurvey).
            then(function() {
                $state.go('admin.provisional');
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
            vm.newSurvey =
            {
                questions: []
            };
        })();
    }
})();