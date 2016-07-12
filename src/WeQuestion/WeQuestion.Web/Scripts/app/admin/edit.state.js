(function () {
    'use strict';

    angular.module('app').config(AdminCreateStateConfig);

    AdminCreateStateConfig.$inject = ['$stateProvider'];
    function AdminCreateStateConfig($stateProvider) {
        $stateProvider
        .state('admin.survey.edit', {
            url: '/edit',
            views: {
                'menu@admin': {
                    template: '<a ui-sref="admin.provisional"> ✕ </a> <a ui-sref="admin.survey({ id: vm.surveyId})"> preview </a>',
                    controller: Menu,
                    controllerAs: 'vm'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/editor.template.html',
                    controller: 'adminEditController',
                    controllerAs: 'vm'
                }
            }
        });

        Menu.$inject = ['$stateParams'];
        function Menu($stateParams) {
            var vm = this;
            vm.surveyId = $stateParams.id;
        }
    }
})();