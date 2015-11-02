'use strict';

(function () {

    angular
	    .module('app')
        .directive('bookkeepingLegoSetDetail', function() {
            return {
            restrict: 'E',
            link: function (scope, element, attrs) {
                scope.title = attrs.title;
            },
            templateUrl: 'app/directiveLegoSetDetail.html'
            };
        });
})();