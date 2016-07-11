(function () {
    'use strict';

    angular.module('app').config(AdminClosedStateConfig);

    AdminClosedStateConfig.$inject = ['$stateProvider', 'surveyState'];
    function AdminClosedStateConfig($stateProvider, surveyState) {

        $stateProvider
        .state('admin.closed', {
            url: '/closed',
            data: {
                currentSurveyState: surveyState.Closed
            },
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/header.template.html'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/statePanel.template.html',
                    controller: 'admin_StatePanelController',
                    controllerAs: 'vm'
                }
            }
        });
    }
})();