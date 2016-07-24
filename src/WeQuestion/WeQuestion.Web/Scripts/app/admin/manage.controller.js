(function() {
    'use strict';

    angular.module('app').controller('adminManageController', adminManageController);

    adminManageController.$inject = ['$state', '$stateParams', 'surveyService'];
    function adminManageController($state, $stateParams, surveyService) {
        var vm = this;

        const surveyId = $stateParams.id;
        vm.check = {
            isSuveyOpen: isSuveyOpen
        }

        vm.action = {
            closed: function () {
                $state.go('admin.survey');
            }
        }

        surveyService.get(surveyId)
        .then(survey => {
            vm.survey = survey;
        });

        function isSuveyOpen() {
            if (vm.survey && vm.survey.closingTimestamp && vm.survey.accessToken)
                return moment(vm.survey.closingTimestamp) > moment();
            return false;
        }
    }
})();