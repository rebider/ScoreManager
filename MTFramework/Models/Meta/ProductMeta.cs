
//*****************************************************************
//
// File Name:   ProductMeta.cs
//
// Description:  Product:
//
// Coder:       CodeSmith Generate
//
// Date:        2014-06-05 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(ProductMeta))]
    public partial class ProductModel
    {
        public partial class ProductMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "产品名称")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Name { get; set; }
            
    		[Display(Name = "排序")]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  SortNo { get; set; }
            
    		[Display(Name = "是否删除")]
            [UIHint("EditDelFlagList")]
            [Range(0,10240000)]
    		public  int?  DelFlag { get; set; }
            
        }
	}
}

