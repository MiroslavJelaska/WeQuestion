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
                     templateUrl: '/Scripts/app/admin/survey-header.template.html',
                     controller: Menu,
                     controllerAs: 'vm'
                 },
                 'content@admin': {
                     templateUrl: '/Scripts/app/admin/survey.template.html',
                     controller: 'adminSurveyController',
                     controllerAs: 'vm'
                 }
            }
        });

        Menu.$inject = ['$stateParams', '$state'];
        function Menu($stateParams, $state) {
            var vm = this;
            vm.surveyId = $stateParams.id;
            vm.stateName = $state.current.name;
        }
    }
})();