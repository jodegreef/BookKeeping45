'use strict';

(function () {

    angular
        .module('app')
        .controller('bookkeepingController', bookkeepingController);

    bookkeepingController.$inject = ['bookkeepingService'];

    function bookkeepingController(bookkeepingService) {
        var vm = this;
        
        
        vm.inventory = [];

        vm.workingCopy = {};

        vm.setWorkingCopy = function (legoset)
        {
            vm.workingCopy = {
                id: legoset.id,
                name: legoset.name,
                number: legoset.number,
                purchasePrice: legoset.purchasePrice,
                isSold: legoset.isSold,
                sellPrice: legoset.sellPrice
            };
        }

        vm.saveItem = function (legoSet) {
            bookkeepingService.save(legoSet)
                .then(function () {
                    notify("Item saved");
                    refreshData();
                });
            
        }

        vm.sellItem = function (id, sellPrice) {
            bookkeepingService.markAsSold(id, sellPrice)
                .then(function () {
                    notify("Item marked as sold");
                })
                .catch(function (message) {
                    notifyError("Something went wrong: "  + message.data.exceptionMessage);
                })
            ;
        }


        var notify = function (message) {
            $.notify(message, { autoHideDelay: 1000, className: 'success' });
        }

        var notifyError = function (message) {
            $.notify(message, { autoHideDelay: 5000, className: 'error' });
        }

        var refreshData = function() {
            bookkeepingService.getInventory().then(function (data) {
                vm.inventory = data;
            }
            );
        };


        refreshData();
    }

})();