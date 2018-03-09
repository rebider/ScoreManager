
//*****************************************************************
//
// File Name:   AccessMeta.cs
//
// Description:  Access:权限表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-27 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(AccessMeta))]
    public partial class AccessModel
    {

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? ProductId { get; set; }

        public partial class AccessMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "角色ID")]
            [Required]
            [DropDownList("DDL_SYS_ROLE", "请选择")]
    		public  int?  RoleID { get; set; }
            
    		[Display(Name = "节点ID")]
            [Required]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  NodeID { get; set; }
            
    		[Display(Name = "是否废弃 1：是； 0 ：否（默认0）")]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "创建人")]
            [UIHint("EditText")]
            [Range(0,100)]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }

            

            
        }
	}
}

