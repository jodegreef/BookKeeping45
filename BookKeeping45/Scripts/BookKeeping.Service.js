(function() {
    'use strict';

    angular
        .module('app')
        .factory('bookkeepingService', bookkeepingService);

    /* @ngInject */
    function bookkeepingService($http, $location, $q) { //, exception) { //, logger) {
    	var isPrimed = false;
        var primePromise;

        var service = {
            getInventory: getInventory,
            ready: ready
        };

        return service;

        function getInventory() {
            return $http.get('/api/inventory')
                .then(getInventoryComplete)
                .catch(function(message) {
                    //exception.catcher('XHR Failed for getInventory')(message);
                    console.log('XHR failed for getInventory: ' + message)
                    $location.url('/');
                });

            function getInventoryComplete(data, status, headers, config) {
            	alert(data);
                return data.data[0].data.results;
            }
        }


        function prime() {
            // This function can only be called once.
            if (primePromise) {
                return primePromise;
            }

            primePromise = $q.when(true).then(success);
            return primePromise;

            function success() {
                isPrimed = true;
                logger.info('Primed data');
            }
        }

        function ready(nextPromises) {
            var readyPromise = primePromise || prime();

            return readyPromise
                .then(function() { return $q.all(nextPromises); })
                .catch(exception.catcher('"ready" function failed'));
        }

    }
})();