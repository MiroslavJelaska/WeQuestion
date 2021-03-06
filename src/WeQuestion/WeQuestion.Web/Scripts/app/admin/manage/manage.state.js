﻿(function () {
    'use strict';

    angular.module('app').config(AdminCreateStateConfig);

    AdminCreateStateConfig.$inject = ['$stateProvider'];
    function AdminCreateStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey.manage', {
            url: '/manage',
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/common/survey-header.template.html',
                    controller: 'surveyHeaderController',
                    controllerAs: 'vm'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/manage/manage.template.html',
                    controller: 'adminManageController',
                    controllerAs: 'vm'
                }
            }
        });
    }
})();