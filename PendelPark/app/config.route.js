(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/explore/explore.html',
                    title: 'explore',
                    settings: {
                        nav: 1,
                        content: '<i class="icon-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/explore',
                config: {
                    templateUrl: 'app/explore/explore.html',
                    title: 'explore',
                    settings: {
                        nav: 1,
                        content: '<i class="icon-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/parkings',
                config: {
                    title: 'parkeringar',
                    templateUrl: 'app/parkings/parkings.html',
                    settings: {
                        nav: 2,
                        content: '<i class="icon-lock"></i> Admin'
                    }
                }
            }
        ];
    }
})();