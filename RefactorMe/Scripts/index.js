
var appModule = angular.module('indexModule', []);

appModule.directive('mySortGroup', function () {
    return {
        restrict: 'A',
        controller: ['$scope', function ($scope) {
            $scope.headings = [];
            this.addChild = function (child) {
                child.addClass('mysort');
                $scope.headings.push(child);
            };
            this.sortChild = function (child, desc) {
                $scope.headings.forEach(function (element) {
                    element.removeClass('mysort-desc');
                    element.removeClass('mysort-asc');
                });
                if (desc) {
                    child.removeClass('mysort-desc');
                    child.addClass('mysort-asc');
                } else {
                    child.removeClass('mysort-asc');
                    child.addClass('mysort-desc');
                }
            }
        }],
        link: function (scope, element, attrs) {

        },
    };
});

appModule.directive('mySortHeading', function () {
    return {
        require: '^mySortGroup',
        restrict: 'A',
        scope: {
            sortId: '@sortId',
            onSort: '&onSort',
        },
        link: function (scope, element, attrs, mySortGroupController) {
            scope.desc = false;
            element[element.on ? 'on' : 'bind']('click', function () {
                scope.onSort({ sortId: scope.sortId, desc: scope.desc });
                scope.desc = !scope.desc;
                mySortGroupController.sortChild(element, scope.desc);
            });
            mySortGroupController.addChild(element);
        }
    };
});


appModule.controller('DataController', ['$scope', '$http', function ($scope, $http) {
    $scope.productList = [];
    $scope.currencies = [];
    $scope.currencyName = "USD";
    $scope.orderBy = 0;
    $scope.desc = false;

    $scope.init = function () {
        $scope.getCurrencies();
        $scope.fetchData();
    };

    $scope.getCurrencies = function(){
        $http({
            method: 'GET', url: '../Api/GetCurrencyList',
            data: {}
        }
        ).then(function (response) {
            $scope.currencies = response.data;
            $scope.currencyName = $scope.currencies[0];
        }, function () {
        alert('something wrong :( ');
        });
    }

    $scope.fetchData = function (orderBy, desc) {
        if (orderBy === undefined)
            orderBy = 0;
        if (desc === undefined)
            desc = true;
        $http({
            method: 'POST', url: '../Api/GetProductList',
            data: {currencyName:$scope.currencyName, order: orderBy, desc: desc }
        }
            ).then(function (response) {
                $scope.productList = response.data;
            }, function () {
                alert('something wrong :( ');
            });
    };

    $scope.onSort = function (orderBy, desc) {
        $scope.orderBy = orderBy;
        $scope.desc = desc;
        $scope.fetchData(orderBy, desc);
    };

    $scope.changedCurrency = function (currencyName) {
        $scope.fetchData($scope.orderBy, $scope.desc);
    }
    $scope.init();
}]);
