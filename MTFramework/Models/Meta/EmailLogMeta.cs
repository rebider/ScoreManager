
//*****************************************************************
//
// File Name:   EmailLogMeta.cs
//
// Description:  EmailLog:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(EmailLogMeta))]
    public partial class EmailLogModel
    {
        [ResultColumn("BeginTime")]
        [UIHint("EditText")]
        [Display(Name = "开始时间")]
        public DateTime? BeginTime { get; set; }

        [ResultColumn("EndTime")]
        [UIHint("EditText")]
        [Display(Name = "结束时间")]
        public DateTime? EndTime { get; set; }
        public partial class EmailLogMeta
        {
    		[Display(Name = "邮件ID")]
            [Required]
            [UIHint("EditText")]
            public  string  EmailID { get; set; }
            
    		[Display(Name = "邮件模板ID")]
            [Required]
            [UIHint("EditText")]
    		public  string  EmailTempID { get; set; }
            
    		[Display(Name = "邮件标题")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  EmailTitle { get; set; }
            
    		[Display(Name = "邮件内容")]
            [Required]
            [UIHint("EditText")]
            [StringLength(16)]
    		public  string  EmailContents { get; set; }
            
    		[Display(Name = "平台账户")]
            [Required]
            [UIHint("EditText")]
    		public  int?  ReceiveUserID { get; set; }
            
    		[Display(Name = "关联Mt4账户")]
            [UIHint("EditText")]
    		public  int?  Account { get; set; }
            
    		[Display(Name = "收件人邮箱")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Receviewer { get; set; }
            
    		[Display(Name = "发送人名称")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Sender { get; set; }
            
    		[Display(Name = "发送时间")]
            [Required]
            [UIHint("EditText")]
    		public  DateTime?  SendTime { get; set; }
            
    		[Display(Name = "发送结果")]
            [UIHint("EditText")]
    		public  int?  SendStatus { get; set; }
            
    		[Display(Name = "说明")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Remark { get; set; }
            
    		[Display(Name = "发送类型  群发1 点对点0")]
            [UIHint("EditText")]
    		public  int?  SendType { get; set; }
            
        }
	}
}

