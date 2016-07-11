(function() {
    'use strict';

    angular.module('app').controller('adminCreateController', adminCreateController);

    adminCreateController.$inject = ['$state', 'surveyService'];

    function adminCreateController($state, surveyService) {
        var vm = this;

        vm.action = {
            submit: submit,
            addQuestion: addQuestion,
            addOption: addOption
        };

        vm.treeOptions = {
            accept: function (sourceNodeScope, destNodesScope, destIndex) {
                return destNodesScope.isParent(sourceNodeScope);
            }
        }

        function submit() {
            console.log(vm.newSurvey);
            surveyService.create(vm.newSurvey)
                .then(x => console.log(x));
        }

        function addQuestion() {
            vm.newSurvey.questions.push({
                'title': ''
            });
        }

        function addOption(question) {
            question.options = question.options || [];
            question.options.push({
                'title': ''
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