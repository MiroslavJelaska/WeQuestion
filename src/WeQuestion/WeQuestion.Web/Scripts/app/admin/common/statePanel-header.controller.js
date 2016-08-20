(function () {
    'use strict';

    angular.module('app').controller('statePanelHeaderController', statePanelHeaderController);

    statePanelHeaderController.$inject = ['$stateParams', '$state', 'authorizationService'];
    function statePanelHeaderController($stateParams, $state, authorizationService) {
        var vm = this;
        vm.surveyId = $stateParams.id;
        vm.stateName = $state.current.name;

        vm.action = {
            logout: logout
        }

        function logout() {
            console.log(1235)
            authorizationService.logout();
            $state.go('login');
        }
    }
})();