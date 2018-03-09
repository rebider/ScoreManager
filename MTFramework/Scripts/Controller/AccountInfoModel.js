
app.controller('accountInfo', function ($scope, $http) {
    $scope.CurrentPage = 1;  
    $http.post("/Web/MyAccount/GetAccountInfo", { CurrentPage: 1, userId: 28 }).success(function (data) {
        $scope.accounts = data.datas;
    });

    $scope.Leverage = 0;
    $scope.SureEdit = function () {
        $http.post("/Web/MyAccount/AccountOpt", { AccountID: 7, Leverage: $scope.Leverage }).success(function (data) {
            console.log(data);
        });
    }
    $scope.loading = function() {
        return layer.msg('重置中...', { icon: 16, shade: [0.5, '#f5f5f5'], scrollbar: false, offset: '', time: 100000 });
    }
    $scope.loadOver = function(index) {
        layer.close(index);
    }
    $scope.ResetPwd = function () {
        layer.confirm('确认调整状态？', {
            btn: ['确认', '取消'] //可以无限个按钮  
        }, function (index, layero) {
            //按钮【按钮一】的回调
            var i;
                $.ajax({
                    url: "/Web/MyAccount/ForgetAccountPassword",
                    type: "POST",
                    data: {"id": 53 },
                    success: function (data) {
                        if (data.status == 1) {
                            layer.open({
                                content: "修改成功",
                                yes: function (index, layero) {
                                    location.href = "#/myAccount";
                                    layer.close(index); //如果设定了yes回调，需进行手工关闭
                                }
                            });

                        }
                    },
                    beforeSend: function () {
                        i = $scope.loading();
                    },
                    error: function (e, jqxhr, settings, exception) {
                        loadOver(i);
                    }
                });
            });
    }
    $scope.UserID = 0;
    $scope.AccountType = 0;
    $scope.Leverage = "";
    $scope.SureAdd = function () {
        $http.post("/Web/MyAccount/AccountOpt", { AccountType: $scope.AccountType, Leverage: $scope.Leverage, UserID: $scope.UserID, ServerID: 12, Mt4Name: "123", GroupName: 1, Status: 1 }).success(function (data) {
            console.log(data);
        });
    }

    $scope.inmoney = 0;
    $scope.outmoney = 0;
    $scope.money = 0;
    $scope.userId = 14;
    $scope.sreamtype = 3;
    $scope.change = function () {
        $http.post("/Web/FinaceManage/FinaceManage", { UserID: $scope.outmoney, AccountID: $scope.inmoney, StreamMoney: $scope.money, StreamType: $scope.sreamtype }).success(function (data) {
            console.log(data);
        });
    }

    $scope.UserID = 14;
    $http.post("/Web/FinaceManage/getMoneyStreamList", { UserID: $scope.UserID }).success(function (data) {
        $scope.mslist = data.datas;
    });
});
