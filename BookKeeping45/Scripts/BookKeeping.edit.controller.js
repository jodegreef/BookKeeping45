﻿'use strict';

(function () {

    angular
        .module('app')
        .controller('bookkeepingEditController', function ($scope, $uibModalInstance, legoSet) {
            var vm = this;
            $scope.selected = legoSet;

            $scope.ok = function () {
                $uibModalInstance.close($scope.selected);
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        });

})();