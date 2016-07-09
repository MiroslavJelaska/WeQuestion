(function () {
    'use strict';

    angular.module('app').config(Admin_SurveyStateConfig);

    Admin_SurveyStateConfig.$inject = ['$stateProvider'];
    function Admin_SurveyStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey', {
            url: '/survey/{id:int}',
            templateUrl: '/Scripts/app/admin/admin.survey.template.html',
            controller: 'adminSurveyController',
            controllerAs: 'vm'
        });
    }
})();