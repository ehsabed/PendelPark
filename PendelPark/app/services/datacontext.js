(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId,
        ['$http', '$rootScope', 'common', 'config', datacontext]);

    function datacontext($http, $rootScope, common, config) {
        var $q = common.$q;
        var apiUrl = config.apiUrl;
        var events = config.events;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logError = getLogFn(serviceId, 'error');
        var logSuccess = getLogFn(serviceId, 'success');
        var primePromise;

        var service = {
            //cancel: cancel,
            //markDeleted: markDeleted,
            getAllParkings: getAllParkings,
            getFavoriteParkings: getFavoriteParkings,
            getParkingCounts: getParkingCounts,
            prime: prime,
            //save: save,
            // sub-services
            //zStorage: zStorage,
            //zStorageWip: zStorageWip
            // Repositories to be added on demand:
            //      attendee
            //      lookup
            //      session
            //      speaker
        };

        init();

        return service;

        function init() {
            // TODO: Do all initialization here
            //zStorage.init(manager);
            //zStorageWip.init(manager);
            //repositories.init(manager);
            //defineLazyLoadedRepos();
            //setupEventForHasChangesChanged();
            //setupEventForEntitiesChanged();
            //listenForStorageEvents();
        }

        //function cancel() {
        //    if (manager.hasChanges()) {
        //        manager.rejectChanges();
        //        logSuccess('Canceled changes', null, true);
        //    }
        //}

        /*
         * Return all parkings.
         */
        function getAllParkings() {
            var parkings = [];

            // TODO: Fetch real data
            return $http({ method: 'GET', url: apiUrl });
            // return $q.when(parkings);
        }

        /*
         * Return the user's favorite parkings.
         */
        function getFavoriteParkings(user) {
            var favParks = [];

            if (user === null) {
                return $q.when(favParks);
            }

            // TODO: Fetch real data
            favParks = [1, 2, 4];

            return $q.when(favParks);
        }

        /*
         * Return total no of parkings and total no of free spaces.
         */
        function getParkingCounts() {
            // TODO: Fetch real data
            var pCounts = [
                { totParkings: 315, freeParkings: 101, unknown: 8 }
            ];

            return $q.when(pCounts);
        }

        function prime() {
            if (primePromise) return primePromise;

            //// look in local storage, if data is here, 
            //// grab it. otherwise get from 'resources'
            //var storageEnabledAndHasData = zStorage.load(manager);
            //primePromise = storageEnabledAndHasData ?
            //    $q.when(log('Loading entities and metadata from local storage')) :
            //    $q.all([service.lookup.getAll(), service.speaker.getPartials(true)])
            //        .then(extendMetadata);

            // TODO: Remove this temp solution
            primePromise = $q.when(42);
            return primePromise.then(success);

            function success() {
                //service.lookup.setLookups();
                //zStorage.save();
                log('Primed the data');
            }

            //function extendMetadata() {
            //    var metadataStore = manager.metadataStore;
            //    model.extendMetadata(metadataStore);
            //    registerResourceNames(metadataStore);
            //}

            //// Wait to call until entityTypes are loaded in metadata
            //function registerResourceNames(metadataStore) {
            //    var types = metadataStore.getEntityTypes();
            //    types.forEach(function (type) {
            //        if (type instanceof breeze.EntityType) {
            //            set(type.shortName, type);
            //        }
            //    });

            //    var personEntityName = entityNames.person;
            //    ['Speakers', 'Speaker', 'Attendees', 'Attendee'].forEach(function (r) {
            //        set(r, personEntityName);
            //    });

            //    function set(resourceName, entityName) {
            //        metadataStore.setEntityTypeForResourceName(resourceName, entityName);
            //    }
            //}
        }
    }
})();