(function () {
    'use strict';

    angular.module('app').constant('surveyState', new Enumeration({
        1: 'provisional',
        2: 'open',
        3: 'closed'
    }));
})();
