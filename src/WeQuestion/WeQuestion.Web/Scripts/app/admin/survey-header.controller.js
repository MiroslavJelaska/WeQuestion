(function () {
    'use strict';

    angular.module('app').controller('surveyHeaderController', surveyHeaderController);

    surveyHeaderController.$inject = ['$stateParams', '$state', '$scope', 'ngDialog', 'surveyService', 'surveyState'];
    function surveyHeaderController($stateParams, $state, $scope, ngDialog, surveyService, surveyState) {
        var vm = this;
        vm.surveyId = $stateParams.id;
        vm.stateName = $state.current.name;
        vm.surveyState = surveyState;

        vm.action = {
            publish: publish
        }

        $scope.duration = 5;

        fetchSurveyData();

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

        function fetchSurveyData() {
            surveyService.get($stateParams.id)
            .then(function (survey) {
                vm.currentSurveyState = survey.state;
            });
        }
    }
})();