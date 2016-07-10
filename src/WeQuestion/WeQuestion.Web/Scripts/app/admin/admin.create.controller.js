(function () {
    'use strict';

    angular.module('app').controller('adminCreateController', adminCreateController);

    adminCreateController.$inject = ['$state', 'surveyService'];
    function adminCreateController($state, surveyService) {
        var vm = this;

        vm.action = {
            submit: submit,
            addQuestion: addQuestion
        };

        function submit() {
            console.log(vm.newSurvey);
            surveyService.create(vm.newSurvey)
            .then(x => console.log(x));
        }

        function addQuestion() {
            console.log(vm.newSurvey.questions);
            vm.newSurvey.questions.push({});
            console.log(vm.newSurvey.questions);
        }

        (function init() {
            vm.newSurvey =
            {
                questions: []
            };
        })();
    }
})();