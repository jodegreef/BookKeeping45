'use strict';

(function () {

    angular
        .module('app')
        .controller('bookkeepingController', bookkeepingController);

    bookkeepingController.$inject = ['bookkeepingService'];

    function bookkeepingController(bookkeepingService) {
        var vm = this;


        vm.itemMarkedAsSold = function (id, sellPrice) {
            bookkeepingService.getInventory();
        }

        vm.addItem = function () {
            $.notify("item added", { autoHideDelay: 1000, className: 'success' });
        }
        bookkeepingService.getInventory();


    }

})();