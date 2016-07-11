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
                return sourceNodeScope.$id === destNodesScope.$id;
            }
        }

        function submit() {
            console.log(vm.newSurvey);
            surveyService.create(vm.newSurvey)
                .then(x => console.log(x));
        }

        function addQuestion() {
            vm.newSurvey.questions.push({
                'title': 'Naslov'
            });
        }

        function addOption(question) {
            question.options = question.options || [];
            question.options.push({
                'title': 'node1.1.1'
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