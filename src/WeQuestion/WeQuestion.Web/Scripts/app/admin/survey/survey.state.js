(function () {
    'use strict';

    angular.module('app').config(Admin_SurveyStateConfig);

    Admin_SurveyStateConfig.$inject = ['$stateProvider'];
    function Admin_SurveyStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey', {
            url: '/survey/{id:int}',
            views: {
                 'menu@admin': {
                     templateUrl: '/Scripts/app/admin/common/survey-header.template.html',
                     controller: 'surveyHeaderController',
                     controllerAs: 'vm'
                 },
                 'content@admin': {
                     templateUrl: '/Scripts/app/admin/survey/survey.template.html',
                     controller: 'adminSurveyController',
                     controllerAs: 'vm'
                 }
            }
        });
    }
})();