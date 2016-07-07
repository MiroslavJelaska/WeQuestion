(function () {
    'use strict';

    angular.module('app').config(Admin_ProvisionalStateConfig);

    Admin_ProvisionalStateConfig.$inject = ['$stateProvider', 'surveyState'];
    function Admin_ProvisionalStateConfig($stateProvider, surveyState) {
        $stateProvider
        .state('admin.provisional', {
            url: '/provisional',
            data: {
                currentSurveyState: surveyState.Provisional
            },
            templateUrl: '/Scripts/app/admin/admin.statePanel.template.html',
            controller: 'admin_StatePanelController',
            controllerAs: 'vm'
        });
    }
})();