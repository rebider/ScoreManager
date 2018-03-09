
//*****************************************************************
//
// File Name:   EmailTempMeta.cs
//
// Description:  EmailTemp:
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
    [MetadataType(typeof(EmailTempMeta))]
    public partial class EmailTempModel
    {
        [ResultColumn("SendAddress")]
        [UIHint("EditText")]
        [Display(Name = "发件箱")]
        public string SendAddress { get; set; }
        public partial class EmailTempMeta
        {
    		[Display(Name = "邮件模板编号")]
            [Required]
            [UIHint("EditText")]
            public  string  TempID { get; set; }
            
    		[Display(Name = "邮件模板标题")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  TempName { get; set; }
            
    		[Display(Name = "模板地址")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  TempPath { get; set; }
            
    		[Display(Name = "邮件模板编码")]
            [UIHint("EditText")]
            [StringLength(255)]
    		public  string  TempCode { get; set; }
            
    		[Display(Name = "发送邮件编号")]
            [UIHint("EditText")]
    		public  int?  SmtpID { get; set; }

            [Display(Name = "公司名")]
            [UIHint("EditText")]
            [StringLength(255)]
            public string Company { get; set; }

        }
	}
}

