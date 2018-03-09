using System.ServiceModel.Configuration;
using MT.Common;
using MT.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MT.Models;

namespace MT
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            //使用DropDownList属性必须设置
            ModelMetadataProviders.Current = new FieldTemplateMetadataProvider();

            ////定义定时器
            ////1000表示1秒的意思
            //System.Timers.Timer myTimer = new System.Timers.Timer(60000);
            ////TaskAction.SetContent(); //表示要调用的方法
            //myTimer.Elapsed += new System.Timers.ElapsedEventHandler(TaskAction.SetContent);
            //myTimer.Enabled = true;
            //myTimer.AutoReset = true;

        }
        public static class TaskAction
        {
            private static string content = "";
            /// <summary>
            /// 输出信息存储的地方.
            /// </summary>
            public static string Content
            {
                get { return TaskAction.content; }
                set { TaskAction.content += "<div>" + value + "</div>"; }
            }
            /// <summary>
            /// 定时器委托任务 调用的方法
            /// </summary>
            /// <param name="source"></param>
            /// <param name="e"></param>
            public static void SetContent(object source, ElapsedEventArgs e)
            {
                //try
                //{
                //    List<AccountModel> amode = AccountModel.Fetch("select *from Account a left join UserInfo b on a.UserID=b.UserID and b.AgentLevelID=0");
                //    Random random = new Random();
                //    Random random2 = new Random();


                //    for (int i = 0; i < 10; i++)
                //    {
                //        int rd = random.Next(0, amode.Count);

                //        int rd2 = random2.Next(100000, 999999);
                //        int number = random.Next(1, 2);
                //        TradeOrderModel trade = new TradeOrderModel();
                //        trade.Account = amode[rd].Account;
                //        trade.Cmd = number == 1 ? "Buy" : "Sell";
                //        trade.Mt4Order = rd2;
                //        trade.Symbol = "EURUSD";
                //        trade.OpenPrice = 50;
                //        trade.ClosePrice = 60;
                //        trade.Profit = trade.ClosePrice - trade.OpenPrice;
                //        trade.Volume = 10;
                //        trade.OpenTime = DateTime.Now.AddMinutes(-1);
                //        trade.CloseTime = DateTime.Now;
                //        // tmodel.OpenPrice = random.Next(1, 50);
                //        trade.UserID = amode[rd].UserID;
                //        trade.Agent = random.Next(1, 50);
                //        trade.IsSettle = 0;
                //        trade.Bonus = random.Next(1, 50);
                //        trade.ServerID = random.Next(1, 15);
                //        trade.Insert();
                //    }

                //    AgentBounsSettle Settle = new AgentBounsSettle();
                //    Settle.AutoBonusSettle();

                //}
                //catch (Exception err)
                //{
                //    //===============================================================================
                //    FileStream fss = new FileStream("E:\\Web\\CRM\\gb.txt", FileMode.Create);                  //
                //    //获得字节数组                                                                  //
                //    byte[] datas = System.Text.Encoding.Default.GetBytes(err.Message);
                //    //开始写入
                //    fss.Write(datas, 0, datas.Length);
                //    //清空缓冲区、关闭流
                //    fss.Flush();
                //    fss.Close();
                //    //================================================================================ 
                //    throw;
                //}



            }

            /// <summary>
            /// 应用池回收的时候调用的方法
            /// </summary>
            public static void SetContent()
            {
                Content = "END: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}