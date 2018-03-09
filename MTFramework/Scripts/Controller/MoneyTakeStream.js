
app.controller('moneyTakea', function($scope, $http) {
    $scope.CurrentPage = 1;
    $http.post("/Web/MoneyTake/GetMoneyTakeInfo", { CurrentPage: $scope.CurrentPage }).success(function(data) {
        $scope.myPage = {
            currentPage: data.datas.CurrentPage, //访问第几页数据，从1开始
            totalItems: data.datas.TotalPages, //数据库中总共有多少条数据
            itemsPerPage: 20 //默认每页展示多少条数据，可更改
        };

        $scope.MoneyTakeInfo = data.datas.Items;


    });

    $scope.$watch(function() {
        return $scope.myPage.itemsPerPage + ' ' + $scope.myPage.currentPage + ' ' + $scope.myPage.totalItems;
    }, getList);

    function getList() {
        //获取列表需要时，将页码重置为1
        $scope.myPage.currentPage = myPage.pageNub;

        //传给服务器时，页码从0开始
        $http.post("/Web/MoneyTake/GetMoneyTakeInfo", { params: { "CurrentPage": $scope.myPage.currentPage - 1 } })
            .success(function(d) {

                $scope.list = d.data.datas;

                $scope.myPage = {
                    currentPage: data.datas.CurrentPage, //访问第几页数据，从1开始
                    totalItems: data.datas.TotalPages, //数据库中总共有多少条数据
                    itemsPerPage: 20 //默认每页展示多少条数据，可更改

                };


            }).error(function() {

                console.log('error...');
            });

    }

    $scope.list = function () {
        $http.post("/Web/MoneyTake/GetMoneyTakeInfo", { CurrentPage: pageing.pageNo }).success(function (data) {
            $scope.pageing = {
                pageNo: data.datas.CurrentPage,
                itemsCount: data.datas.TotalPages,
                pageSize: 20
            };
            $scope.MoneyTakeInfo = data.datas.Items;
        });
    };

 
    });
