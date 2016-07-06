(function () {
    'use strict';

    angular.module('app').constant('surveyState', new Enumeration({
        1: 'Provisional',
        2: 'Open',
        3: 'Closed'
    }));
})();
