using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Models.ViewModels
{
    public class EmailParams
    {
        /// <summary>
        /// （必填）邮件类型
        /// </summary>
        public string EmailType { get; set; }

        /// <summary>
        /// （必填）接收人用户id
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// （必填）接收人邮箱
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// 回调链接
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// （必填）标题
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// （必填）内容
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 关联账户
        /// </summary>
        public int Account { get; set; }


        /// <summary>
        /// （必填）关联账户
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// （必填）发送类型(1群发，0点对点)
        /// </summary>
        public int SendType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        
        /// <summary>
        /// 参数键值对
        /// </summary>
        public Dictionary<string,string> Params { get; set; }


    }
}