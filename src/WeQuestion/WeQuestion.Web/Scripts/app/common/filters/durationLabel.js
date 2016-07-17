(function () {
    angular.module('app').filter('durationLabel', DurationLabelFilter);

    function DurationLabelFilter() {
        return function (totalDuration) {

            if (!totalDuration)
                return "0";

            var minutes = Math.floor(totalDuration / 60);
            var seconds = totalDuration % 60;
            return (minutes > 0) ? `${minutes}m ${seconds}s` : `${seconds}s`;
        }
    }
})();