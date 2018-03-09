
//*****************************************************************
//
// File Name:   RoleMeta.cs
//
// Description:  Role:角色表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-27 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(RoleMeta))]
    public partial class RoleModel
    {
        public partial class RoleMeta
        {
    		[Display(Name = "主键")]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "角色名称")]
            [Required]
            [UIHint("EditText")]
            [StringLength(20)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "备注")]
            [UIHint("EditTextArea")]
            [StringLength(100)]
    		public  string  Remark { get; set; }
            
    		[Display(Name = "是否废弃 1：是； 0 ：否（默认0）")]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "创建人")]
            [UIHint("EditText")]
    		public  string  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }

            [Display(Name = "排序")]
            [UIHint("EditText")]
            public int? SortNo { get; set; }
            
    		[Display(Name = "修改人")]
    		public  string  ModifyMan { get; set; }
            
    		[Display(Name = "修改时间")]
    		public  DateTime?  ModifyTime { get; set; }
            
        }
	}
}

