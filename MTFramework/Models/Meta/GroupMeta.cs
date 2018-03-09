
//*****************************************************************
//
// File Name:   GroupMeta.cs
//
// Description:  Group:分组表
//
// Coder:       CodeSmith Generate
//
// Date:        2014-04-08 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(GroupMeta))]
    public partial class GroupModel
    {
        public bool HasUsed { get; set; }

        public partial class GroupMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "分组英文名")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "分组名称")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Title { get; set; }
            
    		[Display(Name = "目标容器ID")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Target { get; set; }
            
    		[Display(Name = "URL")]
            [Required]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  Url { get; set; }

            [Display(Name = "IcoCss")]
            [UIHint("EditText")]
            [StringLength(50)]
            public string IcoCss { get; set; }

            [Display(Name = "是否废弃")]
            [Required]
            [UIHint("EditDelFlagList")]
            [Range(0,10240000)]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "排序")]
            [Required]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  SortNo { get; set; }
            
    		[Display(Name = "创建人")]
            [Required]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [Required]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
        }
	}
}

