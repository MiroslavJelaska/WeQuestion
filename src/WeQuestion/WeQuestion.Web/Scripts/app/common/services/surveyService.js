(function () {
    'use strict';

    angular.module('app').factory('surveyService', surveyService);

    surveyService.$inject = ['$q', '$http'];
    function surveyService($q, $http)
    {
        const baseUri = 'api/surveys';

        function getAll(state) {
            const config = {
                params: {
                    'state': state
                }
            };

            return $http
            .get(baseUri, config)
            .then(result => result.data);
        }

        function get(id) {
            return $http
            .get(baseUri + '/' + id)
            .then(result => result.data);
        }

        function getResult(id) {
            return $http
            .get(baseUri + '/' + id + '/result')
            .then(result => result.data);
        }

        function create(newSurvey) {
            return $http
            .post(baseUri, newSurvey)
            .then(result => result.data);
        }

        function update(updatedSurvay) {
            return $http
            .put(baseUri + '/' + updatedSurvay.id, updatedSurvay)
            .then(result => result.data);
        }

        function open(updatedSurvay) {
            return $http
            .post(baseUri + '/' + updatedSurvay.id + '/publish', updatedSurvay)
            .then(result => result.data);
        }

        function close(closeSurvayId) {
            return $http
            .post(baseUri + '/' + closeSurvayId + '/close')
            .then(result => result.data);
        }

        return {
            getAll: getAll,
            get: get,
            getResult: getResult,
            create: create,
            update: update,
            open:   open,
            close:  close
        }
    }
})();
