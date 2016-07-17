(function () {
    'use strict';

    angular.module('app').directive('closingCountdown', closingCountdown);

    closingCountdown.$inject = ['$q', '$http', '$interval', '$interpolate'];
    function closingCountdown($q, $http, $interval, $interpolate)
    {
        return {
            restrict: 'E',
            scope: {
                closingTime: '=',
                totalTimeInMinutes: '='
            },
            template:
                '<div class="__closingCountdownWrapper">' +
                    '<span class="tickCount">{{vm.secondsLeft | durationLabel}}</span>' +
                    '<br/>' +
                    '<progress max="{{vm.totalTimeInMinutes * 60}}" value="{{vm.totalTimeInMinutes*60 - vm.secondsLeft}}" style="width:500px;"></progress>' +
                '</div>',
            controller: ['$scope', function ($scope) {
                var vm = this;

                $scope.$watch('vm.closingTime', function(value) {
                    if (value === undefined) return;
    
                    console.log(value);
                    vm.secondsLeft = moment(vm.closingTime).diff(moment(), 'seconds');
                    console.log(vm.secondsLeft);
                    var timeoutTimer = $interval(function () {
                        vm.secondsLeft--;
                    }, 1000);
                });
            }],
            controllerAs: 'vm',
            bindToController: true
        }
    }
})();
