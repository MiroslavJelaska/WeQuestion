(function () {
    'use strict';

    angular.module('app').constant('roleType', new Enumeration({
        1: 'admin',
        2: 'anonymous'
    }));
})();