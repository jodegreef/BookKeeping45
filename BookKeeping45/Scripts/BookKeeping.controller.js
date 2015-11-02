'use strict';

(function () {

    angular
        .module('app')
        .controller('bookkeepingController', bookkeepingController);

    bookkeepingController.$inject = ['bookkeepingService', '$uibModal'];
    

    function bookkeepingController(bookkeepingService, $uibModal) {
        var vm = this;
        
        vm.inventory = [];

        var saveItem = function (legoSet) {
            bookkeepingService.save(legoSet)
                .then(function () {
                    notify("Item saved");
                    refreshData();
                });
            
        }

        var insertItem = function (legoSet) {
            bookkeepingService.insert(legoSet)
                .then(function () {
                    notify("Item saved");
                    refreshData();
                });

        }


        var deleteSet = function (legoSet) {
            bookkeepingService.deleteSet(legoSet)
                .then(function () {
                    notify("Item deleted");
                    refreshData();
                });

        }

        var markItemAsSold = function (id, sellPrice) {
            bookkeepingService.markAsSold(id, sellPrice)
                .then(function () {
                    notify("Item marked as sold");
                    refreshData();
                })
                .catch(function (message) {
                    notifyError("Something went wrong: "  + message.data.exceptionMessage);
                });
        }

        var notify = function (message) {
            $.notify(message, { autoHideDelay: 5000, className: 'success' });
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

        vm.showAddModal = function () {
            showModal('ModalAdd.html', {}, function (selectedItem) {
                insertItem(selectedItem);
            });
        };

        vm.showEditModal = function (legoset) {
            showModal('ModalEdit.html', legoset, function (selectedItem) {
                saveItem(selectedItem);
            });
        };

        vm.showMarkAsSoldModal = function (legoset) {
            showModal('ModalMarkAsSold.html', legoset, function (selectedItem) {
                markItemAsSold(selectedItem.id, selectedItem.sellPrice);
            });
        };

        vm.showDeleteModal = function (legoset) {
            showModal('ModalDelete.html', legoset, function (selectedItem) {
                deleteSet(selectedItem);
            });
        };

        var showModal = function (template, legoset, onSuccess) {
            var modalInstance = $uibModal.open({
                templateUrl: template,
                controller: 'bookkeepingGenericModalController',
                resolve: {
                    legoSet: function () {
                        return angular.copy(legoset);
                    }
                }
            });

            modalInstance.result.then(
                function (selectedItem) {
                    onSuccess(selectedItem);
                },
                function () {
                    console.log('Modal dismissed at: ' + new Date());
                });
        }


        refreshData();
    }



})();