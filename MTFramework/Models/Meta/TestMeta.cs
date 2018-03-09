
//*****************************************************************
//
// File Name:   TestMeta.cs
//
// Description:  Test:测试
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-29 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(TestMeta))]
    public partial class TestModel
    {
        [ResultColumn("UserName")]
        [UIHint("EditText")]
        [Display(Name = "创建人姓名")]
        public string UserName { get; set; }
        public partial class TestMeta
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
            
    		[Display(Name = "图片id")]
            [UIHint("EditText")]
    		public  int?  ImgId { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
    		[Display(Name = "创建人")]
            [UIHint("EditText")]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "是否有效")]
            [UIHint("EditText")]
    		public  int?  DelFlag { get; set; }
            
        }
	}
}

