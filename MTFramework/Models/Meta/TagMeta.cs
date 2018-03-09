
//*****************************************************************
//
// File Name:   TagMeta.cs
//
// Description:  Tag:标签
//
// Coder:       CodeSmith Generate
//
// Date:        2015-03-25 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(TagMeta))]
    public partial class TagModel
    {
        public partial class TagMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "名称")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "排序")]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  SortNo { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
    		[Display(Name = "是否删除")]
            [UIHint("EditDelFlagList")]
            [Range(0,10240000)]
    		public  int?  DelFlag { get; set; }
            
        }
	}
}

