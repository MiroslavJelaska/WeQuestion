(function () {
    'use strict';

    angular.module('app').controller('ParticipantController', ParticipantController);

    ParticipantController.$inject = ['$state', '$stateParams'];
    function ParticipantController($state, $stateParams) {
        var vm = this;

        const surveyId = $stateParams.id;
        console.log(surveyId);
    }
})();