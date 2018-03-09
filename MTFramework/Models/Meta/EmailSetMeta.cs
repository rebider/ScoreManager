
//*****************************************************************
//
// File Name:   EmailSetMeta.cs
//
// Description:  EmailSet:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(EmailSetMeta))]
    public partial class EmailSetModel
    {
        public partial class EmailSetMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "Smtp服务器")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  SmtpServer { get; set; }
            
    		[Display(Name = "是否启用安全链接")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  SafeType { get; set; }
            
    		[Display(Name = "SMTP端口")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  SmtpPort { get; set; }
            
    		[Display(Name = "SMTP账户")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  SmtpAccount { get; set; }
            
    		[Display(Name = "SMTP密码")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  SmtpPassword { get; set; }
            
    		[Display(Name = "发件人邮箱")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  EmailAccount { get; set; }
            
    		[Display(Name = "发件人名称")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  EmailName { get; set; }
            
        }
	}
}

