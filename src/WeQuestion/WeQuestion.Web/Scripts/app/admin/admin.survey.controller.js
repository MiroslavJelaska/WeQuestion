(function () {
    'use strict';

    angular.module('app').controller('adminSurveyController', adminSurveyController);

    adminSurveyController.$inject = ['$state', '$stateParams', 'surveyService'];
    function adminSurveyController($state, $stateParams, surveyService) {
        var vm = this;

        const surveyId = $stateParams.id;
        surveyService.get(surveyId)
        .then(survey => vm.survey = survey);
    }
})();