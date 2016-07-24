(function () {
    'use strict';

    angular.module('app').directive('closingCountdown', closingCountdown);

    closingCountdown.$inject = ['$q', '$http', '$interval'];
    function closingCountdown($q, $http, $interval)
    {
        return {
            restrict: 'E',
            scope: {
                closingTime: '=',
                totalTimeInMinutes: '=',
                onClosed: '&'
            },
            template:
                '<div class="__closingCountdownWrapper">' +
                    '<span class="tickCount">{{ vm.helper.getSecondsLeft() | durationLabel}}</span>' +
                    '<br/>' +
                    '<progress max="{{vm.totalTimeInMinutes * 60 * 100}}" value="{{vm.totalTimeInMinutes * 60 * 100 - vm.secondsLeft}}" style="width:500px;"></progress>' +
                '</div>',
            controller: ['$scope', function ($scope) {
                var vm = this;
                var timeoutTimer = $interval(function () {
                    vm.secondsLeft--;
                    if (vm.secondsLeft <= 0) {
                        console.log('finio finire');
                        $interval.cancel(timeoutTimer);
                        vm.onClosed();
                    }
                }, 10);

                vm.helper = {
                    getSecondsLeft: function () {
                        return Math.floor(vm.secondsLeft / 100);
                    }
                }

                $scope.$watch('vm.closingTime', function (value) {
                    if (value === undefined) return;
                    vm.secondsLeft = moment(vm.closingTime).diff(moment(), 'seconds') * 100;
                });
            }],
            controllerAs: 'vm',
            bindToController: true
        }
    }
})();
