var orderApp = angular.module("MOKApp", []);
orderApp.controller("OrdersCtrl",['$scope', '$attrs', 'orderService', '$window', function($scope, $attrs, orderService, $window) {

    $scope.ordersAndOffers = JSON.parse($attrs.offerItems);
    $scope.orders = $scope.ordersAndOffers.Orders;
    $scope.editOrder = function(orderId) {
        orderService.editOrder(orderId)
            .then(function (response) {
                angular.forEach(response.Items, function(item) {
                    alert(item.OrderId);
                    $scope.order[item.OrderId].quantity = item.quantity;
                    $scope.order[item.OrderId].order = item.order;
                });

            });
    };

    $scope.order = $scope.orders.Offers;
    $scope.count = function () {
        var count = 0;
        angular.forEach($scope.offer.items, function (item) {
            if (item.checked) { count++ }
        });
        return count;
    };
    $scope.saveOrder = function (order) {
        orderService.saveOrder(order)
            .then(function (response) {
                if (response) {
                    $window.location.href = "/Order/Index";
                }
            });
    };

    $scope.resetValidation = function (formItem) {
        formItem.$$parentForm[formItem.$name].isPopoverOpen = false;
        formItem.$$parentForm[formItem.$name].$setValidity("", true);
        formItem.$$parentForm[formItem.$name].errors = null;
    };
}]);