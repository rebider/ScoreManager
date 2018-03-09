var app = angular.module('agentinfo', []);

app.controller('getacclist', function ($scope, $http) {
    $scope.IB = 1;
    $http.post('/Web/AgentArea/GetAccountList', { IB: $scope.IB }).success( function (data) {
        $scope.acclist = data.datas;
    });
});

app.controller('getagenturl', function($scope, $http) {
    $scope.userId = 14;
    $http.post('/Web/AgentArea/GetAgentURL', { userId: $scope.userId }).success(function (data) {
        $scope.agenturl=data.info;
    });
   
    $scope.showcode = function () {
        $http.post('/Web/AgentArea/CreateCode', { str: $scope.agenturl }).success(function (data) {
            $scope.filename = data.info;
        });
    }
});

app.controller('getbonuslist', function($scope, $http) {
    $scope.IB = 1;
    $http.post('/Web/AgentArea/GetBonusList', { IB: $scope.IB }).success(function (data) {
        $scope.bonuslist = data.datas;
        
    });
});

app.controller('getsumbonus', function ($scope, $http) {
    $scope.IB = 1;
    $http.post('/Web/AgentArea/GetSumBonus', { IB:$scope.IB }).success(function (data) {
        $scope.bonus = data.info;
    });
    $scope.settle = function() {
        $http.post('/Web/AgentArea/BonusSettle', { IB: $scope.IB}).success(function (data) {
            console.log(data);
        });
    }
});