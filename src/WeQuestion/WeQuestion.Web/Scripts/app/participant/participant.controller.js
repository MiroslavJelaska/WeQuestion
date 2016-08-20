(function () {
    'use strict';

    angular.module('app').controller('ParticipantController', ParticipantController);

    ParticipantController.$inject = ['$state', '$http', '$stateParams', 'surveyService', 'authorizationService'];
    function ParticipantController($state, $http, $stateParams, surveyService, authorizationService) {
        var vm = this;
        vm.isLoading = true;
        const surveyAccessToken = $stateParams.id;
        vm.check = {
            isSuveyOpen: isSuveyOpen
        }
        vm.action = {
            uncheckOtherOptions: uncheckOtherOptions,
            submit: submit
        }
        
        var authDetails = authorizationService.getAuthDetails();

        if (!authDetails) {
            authorizationService.loginAnonymously()
            .then(function() {
                console.log('loginAnonymously', authorizationService.getAuthDetails());
                loadSurvey();
            });
        } else {
            loadSurvey();
        }

        function loadSurvey() {
            $http.get('api/participation/' + surveyAccessToken)
            .then(function(result) {
                console.log(result);
                vm.survey = result.data;
                vm.isLoading = false;
             });
        }

        function isSuveyOpen() {
            if (vm.survey && vm.survey.closingTimestamp && vm.survey.accessToken)
                return moment(vm.survey.closingTimestamp) > moment();
            return false;
        }

        function uncheckOtherOptions(selectedOption) {
            var question = _.find(vm.survey.questions, function (question) {
                return _.find(question.options, function (option) {
                    return option.$$hashKey === selectedOption.$$hashKey;
                });
            });

            _.each(question.options, function (option) {
                if (option.$$hashKey !== selectedOption.$$hashKey)
                    option.isSelected = false;
            });
        }

        function submit() {
            var data = {
                accessToken: surveyAccessToken
            }
            console.log(vm);

            $http.post("api/participation/", data).
            then(function(response) {
                console.log(response);
            });
        }
    }
})();