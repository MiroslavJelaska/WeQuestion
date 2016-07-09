(function () {
    'use strict';

    angular.module('app').controller('adminCreateController', adminCreateController);

    adminCreateController.$inject = ['$state', 'surveyService'];
    function adminCreateController($state, surveyService) {
        var vm = this;

        vm.action = {
            submit: submit
        };

        function submit() {
            console.log(vm.newSurvey);
            surveyService.create(vm.newSurvey)
            .then(x => console.log(x));
        }
    }
})();