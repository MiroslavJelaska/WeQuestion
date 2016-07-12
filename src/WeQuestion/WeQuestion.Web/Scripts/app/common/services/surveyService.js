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

        return {
            getAll: getAll,
            get:    get,
            create: create,
            update: update
        }
    }
})();
