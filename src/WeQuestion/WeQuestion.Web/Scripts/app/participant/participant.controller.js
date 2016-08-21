(function () {
    'use strict';

    angular.module('app').controller('ParticipantController', ParticipantController);

    ParticipantController.$inject = ['$state', '$http', '$stateParams', 'surveyService', 'authorizationService'];
    function ParticipantController($state, $http, $stateParams, surveyService, authorizationService) {
        var vm = this;
        vm.isLoading = true;
        vm.hasAlreadyParticipated = false;
        const surveyAccessToken = $stateParams.id;
        vm.check = {
            isSuveyOpen: isSuveyOpen
        };

        vm.action = {
            uncheckOtherOptions: uncheckOtherOptions,
            submit: submit
        };

        (function () {
            var participatedSurveys = JSON.parse(localStorage.getItem('participatedSurveys'));
            var hasAlreadyParticipated = !!_.find(participatedSurveys, function(participatedAccessToken) {
                return participatedAccessToken === surveyAccessToken;
            });

            if (hasAlreadyParticipated) {
                vm.hasAlreadyParticipated = true;
                return;
            }

            var authDetails = authorizationService.getAuthDetails();
            if (!authDetails) {
                authorizationService.loginAnonymously()
                .then(function() {
                    loadSurvey();
                });
            } else {
                loadSurvey();
            }
        })();

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
                accessToken: surveyAccessToken,
                answers: _.map(vm.survey.questions, function(question) {
                    return {
                        questionId: question.id,
                        selectedOptionId: getUserAnswerFromOptions(question.options)
                    }
                })
            }
            console.log('vm', vm);
            console.log('data', data);

            $http.post("api/participation/", data).
            then(function (response) {
                var participatedSurveys = JSON.parse(localStorage.getItem('participatedSurveys')) || [];
                participatedSurveys.push(surveyAccessToken);
                localStorage.setItem('participatedSurveys', JSON.stringify(participatedSurveys));

                vm.hasSuccessfulyParticipated = true;
            });

            function getUserAnswerFromOptions(options) {
                var userAnswer = _.find(options, function(option) {
                    return option.isSelected;
                });

                return userAnswer ? userAnswer.id : null;
            }
        }
    }
})();