
//*****************************************************************
//
// File Name:   DemoMeta.cs
//
// Description:  Demo:测试表
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-27 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(DemoMeta))]
    public partial class DemoModel
    {
        public partial class DemoMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "名称")]
            [UIHint("EditText")]
            [StringLength(300)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "单选")]
            [UIHint("EditText")]
    		public  int?  DemoRedioButton { get; set; }
            
    		[Display(Name = "多选")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  DemoCheckBox { get; set; }
            
    		[Display(Name = "下拉")]
            [UIHint("EditText")]
    		public  int?  DemoSelected { get; set; }
            
    		[Display(Name = "文本域")]
            [UIHint("EditTextArea")]
            [StringLength(16)]
    		public  string  DemoTextArea { get; set; }
            
    		[Display(Name = "文本框")]
            [UIHint("EditText")]
            [StringLength(6000)]
    		public  string  DemoText { get; set; }
            
    		[Display(Name = "手机号码")]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  Phone { get; set; }
            
    		[Display(Name = "身份证")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  IDCard { get; set; }
            
    		[Display(Name = "创建人")]
            [UIHint("EditText")]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  Createtime { get; set; }
            
    		[Display(Name = "是否有效")]
            [Required]
            [UIHint("EditDelFlagList")]
    		public  int?  DelFlag { get; set; }
            
        }
	}
}

