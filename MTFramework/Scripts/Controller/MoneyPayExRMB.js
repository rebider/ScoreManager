app.controller('updateMoneyPay', function ($scope, $http) {
    
    $http.post("/Web/MoneyPay/UpdateMoneyPay", { CurrentPage: $scope.CurrentPage }).success(function (data) {
      
    });
});