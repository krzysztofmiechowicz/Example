(function() {
    var serviceOrderApp = angular.module("orderApp");
    serviceOrderApp.factory('orderService', [ '$http', function($http) {
            return {
                saveOrder: function(order) {
                    return $http.post('/Order/Create', { order: order })
                        .success(function () {
                            return true;
                        })
                        .error(function (data, status) {
                            console.error('Repos error', status, data);
                            return false;
                        });
                },
                editOrder: function(orderId) {
                    return $http.get('/Order/Details', { params: { id: orderId } })
                        .then(function(result) {
                            return result.data;
                        });
                }
            }
        }
    ]);
})();