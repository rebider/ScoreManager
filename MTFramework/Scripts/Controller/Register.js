var register = angular.module('registerApp', []);

register.controller('registerCtrl', function ($scope, $http) {
    $scope.lan = "en";
    $scope.userindodetail = {
        Phone: $scope.lan == "en" ? "Phone" : "手机",
        Email: $scope.lan == "en" ? "Email" : "邮箱",
        ConfirmEmail: $scope.lan == "en" ? "Confirm Email" : "邮箱确认",
        Sex: $scope.lan == "en" ? "Sex" : "性别",
        Country: $scope.lan == "en" ? "Country" : "国家",
        UserName: $scope.lan == "en" ? "UserName" : "名字",
        UserNameCn: $scope.lan == "en" ? "UserNameCn" : "姓氏",
        IB: $scope.lan == "en" ? "IB" : "IB代理人",
        Password: $scope.lan == "en" ? "Password" : "密码"
   
    }



    $scope.userinfo= {
        Sex: "",
        UserName: "",
        UserNameCn: "",
        Country: "1",
        Phone: "",
        Email: "",    
        ConfirmEmail: "",
        IB: "",
        PassWord: "",
        ConfirmPassWord: ""
    }
    $scope.$watch('userinfo.Country', function() {
        $scope.userinfo.Phone = $scope.userinfo.Country;
    });
    $scope.adduserinfo = function () {
        if ($scope.userinfo.Email == $scope.userinfo.ConfirmEmail) {
            layer.msg("保存成功");
            return false;
        }
        $http.post("/Web/UserInfo/AddUserInfo", { model: $scope.userinfo }).success(function(data) {
            if (data.isOk) {
                layer.msg("保存成功");
            } else {
                layer.msg("保存失败");
            }
        });

    };
});
