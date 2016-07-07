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
            templateUrl: '/Scripts/app/admin/admin.statePanel.template.html',
            controller: 'admin_StatePanelController',
            controllerAs: 'vm'
        });
    }
})();