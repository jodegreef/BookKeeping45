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
            markAsSold: markAsSold,
            deleteSet: deleteSet,
            save: save,
            insert:insert,
            ready: ready
        };

        return service;

        function getInventory() {
            return $http.get('/api/inventory')
                .then(getInventoryComplete)
                .catch(function(message) {
                    console.log('XHR failed for getInventory: ' + message)
                    $location.url('/');
                });

            function getInventoryComplete(response, status, headers, config) {
                return response.data;
            }
        }

        function markAsSold(id, sellPrice) {
            //fyi: this is how you do a post instead
            // return $http.post('/api/inventory/sold', {id:id, sellPrice: sellPrice})
            return $http.put('/api/inventory/sold/' + id, { sellPrice: sellPrice });
        }


        function insert(legoSet) {
            return $http.post('/api/inventory', legoSet)
                .then(insertComplete)
                .catch(function (message) {
                    //exception.catcher('XHR Failed for getInventory')(message);
                    console.log('XHR failed for post inventory: ' + message)
                    $location.url('/');
                });

            function insertComplete(response, status, headers, config) {
                return response.data;
            }
        }


        function save(legoSet) {
            return $http.put('/api/inventory/' + legoSet.id, legoSet)
                .then(addComplete)
                .catch(function (message) {
                    //exception.catcher('XHR Failed for getInventory')(message);
                    console.log('XHR failed for put inventory: ' + message)
                    $location.url('/');
                });

            function addComplete(response, status, headers, config) {
                return response.data;
            }
        }

        function deleteSet(legoSet) {
            return $http.delete('/api/inventory/' + legoSet.id)
                .then(deleteComplete)
                .catch(function (message) {
                    //exception.catcher('XHR Failed for getInventory')(message);
                    console.log('XHR failed for delete inventory: ' + message)
                    $location.url('/');
                });

            function deleteComplete(response, status, headers, config) {
                return response.data;
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