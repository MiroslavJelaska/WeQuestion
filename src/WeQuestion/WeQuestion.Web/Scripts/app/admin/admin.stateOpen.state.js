(function () {
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
            templateUrl: '/Scripts/app/admin/admin.statePanel.template.html',
            controller: 'admin_StatePanelController',
            controllerAs: 'vm'
        });
    }
})();