(function() {
    'use strict';

    angular.module('app').controller('adminResultsController', adminResultsController);

    adminResultsController.$inject = ['$state', '$stateParams', 'surveyService'];
    function adminResultsController($state, $stateParams, surveyService) {
        var vm = this;

        const surveyId = $stateParams.id;

        surveyService.getResult(surveyId)
        .then(result => {
            vm.result = result;
            console.log(result)
        });
    }
})();