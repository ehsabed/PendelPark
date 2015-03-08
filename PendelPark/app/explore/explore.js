(function () {
    'use strict';
    var controllerId = 'explore';
    angular.module('app').controller(controllerId, ['$scope', 'common', 'datacontext', explore]);

    function explore($scope, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        vm.exploreNearby = '';
        vm.title = 'Utforska';
        vm.favoriteParkings = [];
        vm.parkings = [];
        vm.parkingCounts = [];
        vm.totalNoOfParkings = 0;
        vm.totalNoOfFreeParkings = 0;
        vm.unknownParkings = 0;
        vm.map = {
            center: {
                latitude: 57.708405,
                longitude: 11.973297
            },
            draggable: 'true',
            zoom: 12
        };

        vm.markers = [];

        activate();

        function activate() {
            var promises = [getAllParkings(), getFavoriteParkings()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Explore View'); });
        }

        function getFavoriteParkings() {
            // TODO: Get real user id
            var user = 'olle@mail.com';
            return datacontext.getFavoriteParkings(user).then(function (data) {
                return vm.favoriteParkings = data;
            });
        }

        function getParkingCounts() {
            return datacontext.getParkingCounts().then(function (data) {
                if (data) {
                    vm.totalNoOfParkings = data.totParkings;
                    vm.totalNoOfFreeParkings = data.freeParkings;
                    vm.unknownParkings = data.unknown;
                }
                return vm.parkingCounts = data;
            });
        }

        function getAllParkings() {
            return datacontext.getAllParkings().then(function (data) {
                updateParkings(data.data);
                updateMarkers();
            });
        }

        var onMarkerClicked = function (marker) {
            marker.showWindow = true;
            $scope.$apply();
            //window.alert("Marker: lat: " + marker.latitude + ", lon: " + marker.longitude + " clicked!!")
        };

        function updateParkings(parkings) {
            vm.totalNoOfParkings = 0;
            vm.totalNoOfFreeParkings = 0;
            vm.unknownParkings = 0;
            _(parkings).forEach(function (p) {
                vm.totalNoOfParkings += p.parkingSpaces;
                if (p.freeSpaces) {
                    vm.totalNoOfFreeParkings += p.freeSpaces;
                } else {
                    ++vm.unknownParkings;
                }
            });
            return vm.parkings = parkings;
        }

        function updateMarkers() {
            vm.markers = [];
            _(vm.parkings).forEach(function (p) {
                var marker = {
                    "id": p.id,
                    "coords": { "latitude": p.latitude, "longitude": p.longitude },
                    "icon": { "url": "/Content/images/F29-2.png", "scaledSize": {"height": 26, "width": 32} },
                    "name": p.name,
                    "freeSpaces": p.freeSpaces,
                    "parkingSpaces": p.parkingSpaces
                };
                marker.closeClick = function () {
                    marker.showWindow = false;
                    $scope.$apply();
                };
                marker.onClicked = function () {
                    onMarkerClicked(marker);
                };
                vm.markers.push(marker);
            });
        }
    }
})();