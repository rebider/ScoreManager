var app = angular.module('login', []);

app.controller('loginCtrl', function ($scope,$http) {
    $scope.email = "";
    $scope.password = "";
    $scope.verify = "";
    $scope.rememberok = false;
    $scope.remember = "";
    $scope.clickremember = function () {
        console.log($scope.rememberok);
        if ($scope.rememberok ) {
            $scope.remember = "1";
        }else {
            $scope.remember = "";
        }
        console.log($scope.remember);
    }

    $scope.login = function () {
        if ($scope.email+""=="") {
            layer.msg("请填写登录邮箱！");
        } else if ($scope.password + "" == "") {
            layer.msg("请填写密码！");

        } else if ($scope.verify + "" == "") {
            layer.msg("请填写验证码！");

        }
        $http.post("/web/Public/Login", { Email: $scope.email, Password: $scope.password, verify: $scope.verify, remember: $scope.remember })
        .success(function (data) {
                if (data.status == 0) {
                    layer.msg(data.msg);
                } else {
                    location.href = "/web/Public/Index";

                }
            });
    }
});


