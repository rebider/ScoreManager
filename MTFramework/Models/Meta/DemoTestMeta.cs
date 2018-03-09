
//*****************************************************************
//
// File Name:   DemoTestMeta.cs
//
// Description:  DemoTest:测试表
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-29 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(DemoTestMeta))]
    public partial class DemoTestModel
    {
        public partial class DemoTestMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "名称")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "标题")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Title { get; set; }
            
    		[Display(Name = "图片ID")]
            [UIHint("EditText")]
    		public  int?  ImgId { get; set; }
            
    		[Display(Name = "性别")]
            [UIHint("EditText")]
    		public  int?  Sex { get; set; }
            
    		[Display(Name = "爱好")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Hobby { get; set; }
            
    		[Display(Name = "金额")]
            [UIHint("EditText")]
    		public  decimal?  Money { get; set; }
            
    		[Display(Name = "创建人")]
            [UIHint("EditText")]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
    		[Display(Name = "是否有效")]
            [UIHint("EditText")]
    		public  int?  DelFlag { get; set; }
            
        }
	}
}

