(function () {
    'use strict';

    angular.module('app').config(AdminCreateStateConfig);

    AdminCreateStateConfig.$inject = ['$stateProvider'];
    function AdminCreateStateConfig($stateProvider) {
        $stateProvider
        .state('admin.create', {
            url: '/create',
            views: {
                'menu@admin': {
                    template: '<div class="close" ui-sref="admin.provisional"><div class="inner"><a>✕</a></div></div>'
                },
                'content@admin': {
                    templateUrl: '/Scripts/app/admin/createOrEdit/editor.template.html',
                    controller: 'adminCreateController',
                    controllerAs: 'vm'
                }
            }
        });
    }
})();