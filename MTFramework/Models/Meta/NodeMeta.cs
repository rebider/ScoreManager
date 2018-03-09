
//*****************************************************************
//
// File Name:   NodeMeta.cs
//
// Description:  Node:节点表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-27 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PetaPoco;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(NodeMeta))]
    public partial class NodeModel
    {

        public string NodeGroupTitle { get; set; }

        public string NodeGroupName { get; set; }

        [ResultColumn]
        public string IsChecked { get; set; }

        public string nocheck { get; set; }

        public partial class NodeMeta
        {
            [Display(Name = "网页标题")]
            [UIHint("EditText")]
            public string HeadTitle { get; set; }

            [Display(Name = "网页关键字")]
            [UIHint("EditText")]
            public string HeadKeywords { get; set; }

            [Display(Name = "网页描述")]
            [UIHint("EditText")]
            public string HeadDescription { get; set; }

    		[Display(Name = "主键")]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "节点英文")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "节点中文")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
            public string  Title { get; set; }


            [Display(Name = "IcoCss")]
            [UIHint("EditText")]
            [StringLength(50)]
            public string IcoCss { get; set; }

            [Display(Name = "是否显示")]
            [Required]
            [UIHint("EditVisibleList")]
    		public  int?  DisplayFlag { get; set; }

            [Display(Name = "所属模块")]
            [DropDownList("DDL_NODE_MODULE")]
            public string Area { get; set; }
            
    		[Display(Name = "父节点")]
            [Required]
            [UIHint("EditText")]
    		public  string  Pid { get; set; }
            
    		[Display(Name = "节点层级")]
            [Required]
            [DropDownList("DDL_NODE_LEVEL")]
    		public  int?  NodeLevel { get; set; }
            
    		[Display(Name = "节点链接")]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  Link { get; set; }
            
    		[Display(Name = "分组主键")]
            [Required]
            //[UIHint("EditText")]
            [DropDownList("DDL_SYS_GROUP", "请选择")]
    		public  int?  GroupID { get; set; }
            
    		[Display(Name = "节点目标容器ID")]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  Target { get; set; }
            
    		[Display(Name = "是否废弃 1：是； 0 ：否（默认0）")]
            [UIHint("EditText")]
    		public  int?  DelFlag { get; set; }
            
    		[Display(Name = "排序")]
            [UIHint("EditText")]
            [Range(0,1024000)]
    		public  int?  SortNo { get; set; }
            
    		[Display(Name = "创建人")]
            [UIHint("EditText")]
    		public  int?  CreateMan { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
    		[Display(Name = "修改人")]
            [UIHint("EditText")]
    		public  int?  ModifyMan { get; set; }
            
    		[Display(Name = "修改时间")]
            [UIHint("EditText")]
    		public  DateTime? ModifyTIme { get; set; }

            
            
        }
	}
}

