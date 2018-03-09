
var app = angular.module('app', ['ui.router', 'mePagination']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.when("", "/myAccount");
    $stateProvider
        .state("myAccount", {
            url: "/myAccount",
            templateUrl: "/Areas/Web/temp/MyAccount.html"
        })
        .state("computers", {
            url: "/computers",
            templateUrl: "/Areas/Web/temp/UserList.html"
        })
      .state("printers", {
          url: "/printers",
          templateUrl: "/Areas/Web/temp/MoneyTakeStream.html"
      })
      .state("blabla", {
          url: "/blabla",
          templateUrl: "/Areas/Web/temp/MoneyTakeStream.html"
      })
      .state("finaceManage", {
          url: "finaceManage",
          templateUrl: "/Areas/Web/temp/FinaceManage.html"
      });
     

});
 
//业务类

