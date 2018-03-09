




app.controller('userlist', function ($scope, $http) {
    $scope.CurrentPage = 1;
    $scope.isShow = true;
    $scope.lan="cn";
    $scope.userindodetail= {
        Phone: $scope.lan == "en" ? "en" : "cn",
        Email: $scope.lan == "en" ? "en" : "cn",
        Sex: $scope.lan == "en" ? "en" : "cn",
        Country: $scope.lan == "en" ? "en" : "cn",
        UserName: $scope.lan == "en" ? "en" : "cn",
        UserNameCn: $scope.lan == "en" ? "en" : "cn",
        IB: $scope.lan == "en" ? "en" : "cn",
        Password: $scope.lan == "en" ? "en" : "cn",
        //CardNo: $scope.lan == "en" ? "en" : "cn",
        //IdCard: $scope.lan == "en" ? "en" : "cn",
        //Birthday: $scope.lan == "en" ? "en" : "cn",
        //UserMoney: $scope.lan == "en" ? "en" : "cn",
        //Address: $scope.lan == "en" ? "en" : "cn"
    }
  
    $http.post("/Web/UserInfo/GetUserInfo", { CurrentPage: 1 }).success(function (data) {
        $scope.userInfo=data.datas;
    });
    $scope.adduserinfo = function () {
        $http.post("/Web/UserInfo/AddUserInfo", { model: $scope.userindodetail, id:$scope.id }).success(function (data) {
            $scope.userInfo = data.datas;
                alert("添加成功");
            });
    }

});
app.controller('userupdate', function ($scope, $http) {
    $scope.id = 14;   //userID
    $scope.Phone = "";
    $scope.Email = "";
    $scope.CardNo = "";
    $http.post("/Web/UserInfo/GetUserInfo", { CurrentPage: 1, id: $scope.id }).success(function (data) {
        $scope.userInfo = data.data;
    });
    $scope.updateuserinfo = function () {
        $http.post("/Web/UserInfo/UpdateUserInfo", { UserID: $scope.id, Email: $scope.Email, Phone: $scope.Phone, cardno: $scope.CardNo }).success(function (data) {
            $scope.userInfo = data.data;
            TotalPages

            console.log($scope.userInfo);
        });
    }
});


//app.controller('countrylist', function ($scope, $http) {
   
//    $http.post("/Web/UserInfo/GetCountryList", { CurrentPage: 1}).success(function (data) {
//        $scope.countryinfo = data.datas;
//    });
   
//});