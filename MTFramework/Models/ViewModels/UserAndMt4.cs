using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    //westffs tradeorder同步
    public class UserAndMt4
    {
        public decimal MoneyIn { get; set; }
        public decimal MoneyOut { get; set; }
        public decimal MoneSum { get; set; }
        public decimal UserBalance { get; set; }
        public decimal UserMt4Balance { get; set; }
        public string UserId { get; set; }

        public List<tradeOrder> torders = new List<tradeOrder>();
    }
    public class tradeOrder
    {
        public string UserId { get; set; }
        public string Symbol { get; set; }
        public decimal Volume { get; set; }
    }
}