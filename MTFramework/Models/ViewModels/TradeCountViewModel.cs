using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class TradeCountViewModel
    {
        public int? UserID { get; set; }
        public decimal? InMoney { get; set; }
        public decimal? OutMoney { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Volume { get; set; }
        public DateTime? InsertTime { get; set; }
        public DateTime? CreateTime { get; set; }

        public string UserName { get; set; }
        public decimal? Volume_Fx { get; set; }
        public decimal? Volume_Me { get; set; }
        public decimal? Volume_Oil { get; set; }
        public decimal? Volume_CFD { get; set; }
    }
}