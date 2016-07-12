(function () {
    'use strict';

    angular.module('app').filter('numberToLetter', numberToLetter);

    function numberToLetter() {

        var alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');
        var baseNumber = alphabet.length;
        return function(number) {
            console.log("sOHOHOHOHOOH");
            debugger;
            var result = '';
            do {
                result = alphabet[number % baseNumber] + result;
                number = number / baseNumber;
            }
            while (Math.floor(number) > 0);

            return result;
        }
    }
})();
