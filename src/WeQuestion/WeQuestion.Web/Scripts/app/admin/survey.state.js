(function () {
    'use strict';

    angular.module('app').config(Admin_SurveyStateConfig);

    Admin_SurveyStateConfig.$inject = ['$stateProvider'];
    function Admin_SurveyStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey', {
            url: '/survey/{id:int}',
            views: {
                 'menu@admin': {
                     templateUrl: '/Scripts/app/admin/survey-header.template.html',
                     controller: Menu,
                     controllerAs: 'vm'
                 },
                 'content@admin': {
                     templateUrl: '/Scripts/app/admin/survey.template.html',
                     controller: 'adminSurveyController',
                     controllerAs: 'vm'
                 }
            }
        });

        Menu.$inject = ['$stateParams', '$state', '$scope', 'ngDialog'];
        function Menu($stateParams, $state, $scope, ngDialog) {
            var vm = this;
            vm.surveyId = $stateParams.id;
            vm.stateName = $state.current.name;

            vm.action = {
                publish: publish
            }

            $scope.duration = 5;
            $scope.confirm = function () {
                console.log(123);
            }
            function publish() {
                var dialog = ngDialog.open({
                    template:         '/Scripts/app/admin/popups/publish.template.html',
                    className:        'ngdialog-publish',
                    scope:            $scope,
                    disableAnimation: true
                });
                dialog.closePromise.then(function(data) {
                    console.log(data.value);
                });
            }
        }
    }
})();