(function () {
    'use strict';

    angular.module('app').factory('surveyService', surveyService);

    surveyService.$inject = ['$q', '$http'];
    function surveyService($q, $http)
    {

        var baseUri = 'api/surveys';
        var routes = {
            getAll: baseUri
        }

        function getAll() {
            return $http.get(routes.getAll).then(result => result.data);
        }
        
        return {
            getAll: getAll
        }
    }
})();
