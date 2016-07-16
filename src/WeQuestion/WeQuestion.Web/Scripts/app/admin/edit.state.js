(function () {
    'use strict';

    angular.module('app').config(AdminCreateStateConfig);

    AdminCreateStateConfig.$inject = ['$stateProvider'];
    function AdminCreateStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey.edit', {
            url: '/edit',
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/survey-header.template.html',
                    controller: 'surveyHeaderController',
                    controllerAs: 'vm'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/editor.template.html',
                    controller: 'adminEditController',
                    controllerAs: 'vm'
                }
            }
        });
    }
})();