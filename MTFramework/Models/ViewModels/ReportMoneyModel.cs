using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    /// <summary>
    /// 出入金数据模型
    /// </summary>
    public class ReportMoneySingleModel
    {
        public string Times { get; set; }
        public decimal SumMoney { get; set; }
    }
    /// <summary>
    /// 注册用户数数据模型
    /// </summary>
    public class ReportUserSingleModel
    {
        public string UserRegistTimes { get; set; }
        public int Registers { get; set; }
    }
    /// <summary>
    /// 交易账户数数据模型
    /// </summary>
    public class ReportAccountSingleModel
    {
        public string AcTimes { get; set; }
        public int AcCount { get; set; }
    }
    /// <summary>
    /// 出入金数据模型
    /// </summary>
    public class ReportMoneyModel
    {
        public List<string> Times { get; set; }        
        public List<decimal> SumInMoney { get; set; }
        public List<decimal> SumOutMoney { get; set; }
        public List<decimal> SumMoney { get; set; }       
    }
    /// <summary>
    /// 交易账户数List数据模型
    /// </summary>
    public class ReportAccountList
    {
        public List<string> AcTimes { get; set; }
        public List<int> AcCount { get; set; }
        
    }
    /// <summary>
    /// 平台用户注册数List数据模型
    /// </summary>
    public class ReportUserList
    {
        public List<string> UserRegistTimes { get; set; }
        public List<int> Registers { get; set; }

    }
    /// <summary>
    /// 交易订单的交易手数、订单数、盈亏
    /// </summary>
    public class TradeOrder
    {
        public string Times { get; set; }//开仓时间
        public decimal Volume { get; set; }//交易手数
        public int Orders { get; set; }//订单数
        public decimal Profit { get; set; }//盈亏
    }
    /// <summary>
    /// 交易订单的交易手数、订单数、盈亏List集合
    /// </summary>
    public class TradeOrderList
    {
        public List<string> Times { get; set; }//开仓时间
        public List<decimal> Volume { get; set; }//交易手数
        public List<int> Orders { get; set; }//订单数
        public List<decimal> Profit { get; set; }//盈亏
    }

    public class OrderSingular
    {
        public List<string> Singular { get; set; }//开仓时间
        public List<string> Symbol { get; set; }//交易手数

    }
}