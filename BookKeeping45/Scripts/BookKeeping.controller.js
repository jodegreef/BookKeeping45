'use strict';

(function () {

    angular
        .module('app')
        .controller('bookkeepingController', bookkeepingController);

    bookkeepingController.$inject = ['bookkeepingService', '$uibModal'];
    

    function bookkeepingController(bookkeepingService, $uibModal) {
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

        vm.deleteSet = function (legoSet) {
            bookkeepingService.deleteSet(legoSet)
                .then(function () {
                    notify("Item deleted");
                    refreshData();
                });

        }

        vm.markItemAsSold = function (id, sellPrice) {
            bookkeepingService.markAsSold(id, sellPrice)
                .then(function () {
                    notify("Item marked as sold");
                    refreshData();
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



        vm.showEditModal = function (legoset) {

            var modalInstance = $uibModal.open({
                templateUrl: 'ModalEdit.html',
                controller: 'bookkeepingEditController',
                resolve: {
                    legoSet: function () {
                        return angular.copy(legoset);
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    vm.saveItem(selectedItem);
                },
                function () {
                    console.log('Modal dismissed at: ' + new Date());
            });
        };


        vm.showMarkAsSoldModal = function (legoset) {

            var modalInstance = $uibModal.open({
                templateUrl: 'ModalMarkAsSold.html',
                controller: 'bookkeepingMarkAsSoldController',
                resolve: {
                    legoSet: function () {
                        return angular.copy(legoset);
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    vm.markItemAsSold(selectedItem.id, selectedItem.sellPrice);

                },
                function () {
                    console.log('Modal dismissed at: ' + new Date());
                });
        };


        vm.showDeleteModal = function (legoset) {

            var modalInstance = $uibModal.open({
                templateUrl: 'ModalDelete.html',
                controller: 'bookkeepingEditController',
                resolve: {
                    legoSet: function () {
                        return angular.copy(legoset);
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    vm.deleteSet(selectedItem);

                },
                function () {
                    console.log('Modal dismissed at: ' + new Date());
                });
        };



        refreshData();
    }



})();