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