(function() {
    'use strict';

    angular.module('app').controller('adminResultsController', adminResultsController);

    adminResultsController.$inject = ['$state', '$stateParams', 'surveyService'];
    function adminResultsController($state, $stateParams, surveyService) {
        var vm = this;

        const surveyId = $stateParams.id;

        vm.action = {
            closed: function () {
                $state.go('admin.survey');
            }
        }

        surveyService.getResult(surveyId)
        .then(result => {
            vm.result = result;
            //vm.accessUrl = 'http://localhost:16871/s/' + vm.survey.accessToken;
        });
    }
})();