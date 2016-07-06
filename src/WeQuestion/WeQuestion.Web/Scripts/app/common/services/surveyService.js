(function () {
    'use strict';

    angular.module('app').factory('surveyService', surveyService);

    surveyService.$inject = ['$q', '$http', 'surveyState'];
    function surveyService($q, $http, surveyState)
    {
        const baseUri = 'api/surveys';
        const routes = {
            getAll: baseUri
        }

        function getAll(state) {
            const config = {
                params: {
                    'state': state
                }
            };

            return $http
            .get(routes.getAll, config)
            .then(result => result.data);
        }
        
        return {
            getAll: getAll
        }
    }
})();
