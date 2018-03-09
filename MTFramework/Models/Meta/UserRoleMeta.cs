
//*****************************************************************
//
// File Name:   UserRoleMeta.cs
//
// Description:  UserRole:用户角色表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-27 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(UserRoleMeta))]
    public partial class UserRoleModel
    {
        [ResultColumn("RoleName")]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }
        public partial class UserRoleMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "用户ID")]
            [Required]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  UserID { get; set; }
            
    		[Display(Name = "角色ID")]
            [Required]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  RoleID { get; set; }
            
    		[Display(Name = "是否废弃")]
            [Required]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "创建人")]
            [Required]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [Required]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
        }
	}
}

