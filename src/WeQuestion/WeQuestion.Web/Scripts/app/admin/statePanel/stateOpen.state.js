﻿(function () {
    'use strict';

    angular.module('app').config(Admin_OpenStateConfig);

    Admin_OpenStateConfig.$inject = ['$stateProvider', 'surveyState'];
    function Admin_OpenStateConfig($stateProvider, surveyState) {
        $stateProvider
        .state('admin.open', {
            url: '/open',
            data: {
                currentSurveyState: surveyState.Open
            },
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/common/statePanel-header.template.html',
                    controller: 'statePanelHeaderController',
                    controllerAs: 'vm'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/statePanel/statePanel.template.html',
                    controller: 'admin_StatePanelController',
                    controllerAs: 'vm'
                }
            }
        });
    }
})();