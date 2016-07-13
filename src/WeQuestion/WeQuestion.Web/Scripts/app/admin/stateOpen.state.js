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
            views: {
                'menu@admin': {
                    templateUrl: '/Scripts/app/admin/header.template.html',
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