﻿(function () {
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
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/statePanel-header.template.html',
                    controller: Menu,
                    controllerAs: 'vm'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/statePanel.template.html',
                    controller: 'admin_StatePanelController',
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