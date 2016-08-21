(function () {
    'use strict';

    angular.module('app').controller('surveyHeaderController', surveyHeaderController);

    surveyHeaderController.$inject = ['$stateParams', '$state', '$scope', 'ngDialog', 'surveyService', 'surveyState', 'authorizationService'];
    function surveyHeaderController($stateParams, $state, $scope, ngDialog, surveyService, surveyState, authorizationService) {
        var vm = this;
        vm.surveyId = $stateParams.id;
        vm.stateName = $state.current.name;
        vm.surveyState = surveyState;
        vm.action = {
            publish: publish,
            close: close,
            closeWindow: closeWindow,
            logout: logout
        }
        var closeWindowStateName = null;
        $scope.duration = 5;

        fetchSurveyData();


        function logout() {
            authorizationService.logout();
            $state.go('login');
        }

        function closeWindow() {
            if (closeWindowStateName) $state.go(closeWindowStateName);
            else $state.go('admin.provisional');
        }

        function publish() {
            surveyService.get(vm.surveyId).then(function (surveyRecord) {
                var doAllQuestionsHaveOneAnswerOptionMarkedAsCorret =
                    _.every(surveyRecord.questions, function(question) {
                        return _.some(question.options, function(option) {
                            return option.isCorrect;
                        });
                    });

                if (!doAllQuestionsHaveOneAnswerOptionMarkedAsCorret) {
                    ngDialog.open({
                        template: '/Scripts/app/admin/popups/cannotPublish.template.html',
                        className: 'ngdialog-cannotPublish',
                        disableAnimation: true
                    });
                } else {
                    var dialog = ngDialog.open({
                        template: '/Scripts/app/admin/popups/publish.template.html',
                        className: 'ngdialog-publish',
                        scope: $scope,
                        disableAnimation: true
                    });

                    dialog.closePromise.then(function(data) {
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
            });
        }

        function close() {
            surveyService.close(vm.surveyId)
            .then(function () {
                $state.go('admin.survey.results');
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