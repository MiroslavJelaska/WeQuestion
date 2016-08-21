(function () {
    'use strict';

    angular.module('app').config(AdminCreateStateConfig);

    AdminCreateStateConfig.$inject = ['$stateProvider'];
    function AdminCreateStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey.results', {
            url: '/results',
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/common/survey-header.template.html',
                    controller: 'surveyHeaderController',
                    controllerAs: 'vm'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/results/results.template.html',
                    controller: 'adminResultsController',
                    controllerAs: 'vm'
                }
            }
        });
    }
})();