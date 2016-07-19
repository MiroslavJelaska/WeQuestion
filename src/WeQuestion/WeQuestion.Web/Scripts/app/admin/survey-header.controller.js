﻿(function () {
    'use strict';

    angular.module('app').controller('surveyHeaderController', surveyHeaderController);

    surveyHeaderController.$inject = ['$stateParams', '$state', '$scope', 'ngDialog', 'surveyService', 'surveyState'];
    function surveyHeaderController($stateParams, $state, $scope, ngDialog, surveyService, surveyState) {
        var vm = this;
        vm.surveyId = $stateParams.id;
        vm.stateName = $state.current.name;
        vm.surveyState = surveyState;
        console.log(vm.surveyState);
        vm.action = {
            publish: publish,
            close: close,
            closeWindow: closeWindow
        }
        var closeWindowStateName = null;
        $scope.duration = 5;

        fetchSurveyData();

        function closeWindow() {
            console.log(closeWindow);
            if (closeWindowStateName) $state.go(closeWindowStateName);
            else $state.go('admin.provisional');
        }

        function publish() {
            var dialog = ngDialog.open({
                template: '/Scripts/app/admin/popups/publish.template.html',
                className: 'ngdialog-publish',
                scope: $scope,
                disableAnimation: true
            });

            dialog.closePromise.then(function (data) {
                if (!data.value) return;
                surveyService.open({
                    id: vm.surveyId,
                    durationInMinutes: data.value
                })
                .then(function(survey) {
                    fetchSurveyData();
                    $state.go('admin.survey.manage');
                });
            });
        }

        function close() {
            surveyService.close(vm.surveyId)
            .then(function() {
            });
        }

        function fetchSurveyData() {
            surveyService.get($stateParams.id)
            .then(function (survey) {
                vm.currentSurveyState = survey.state;
                closeWindowStateName = 'admin.' + surveyState[survey.state];
            });
        }
    }
})();