using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class ServiceResponse
    {
        private string _msg = "";

        public ServiceResponse()
        {
            Status = 0;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Msg { get { return _msg; } set { _msg = value; } }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

    }
}