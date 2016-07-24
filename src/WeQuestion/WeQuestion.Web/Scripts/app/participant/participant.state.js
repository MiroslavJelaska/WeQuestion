(function () {
    'use strict';

    angular.module('app').config(Admin_ParticipantStateConfig);

    Admin_ParticipantStateConfig.$inject = ['$stateProvider'];
    function Admin_ParticipantStateConfig($stateProvider) {
        $stateProvider
        .state('participant', {
            url: '/q/{id:string}',
            views: {
                'menu': {
                    template: null
                },
                'content': {
                     templateUrl: '/Scripts/app/participant/participant.template.html',
                     controller: 'ParticipantController',
                     controllerAs: 'vm'
                 }
            }
        });
    }
})();