
//*****************************************************************
//
// File Name:   SystemParamMeta.cs
//
// Description:  SystemParam:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace MT.Models
{
    [Serializable]
    [MetadataType(typeof(SystemParamMeta))]
    public partial class SystemParamModel
    {
        public partial class SystemParamMeta
        {
    		[Display(Name = "参数编号")]
            [Required]
            [UIHint("EditText")]
            public  string  ParamID { get; set; }
            
    		[Display(Name = "参数名称")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  ParamName { get; set; }
            
    		[Display(Name = "参数值")]
            [Required]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  ParamValue { get; set; }
            
    		[Display(Name = "描述")]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  Description { get; set; }
            
    		[Display(Name = "其他备注")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  Remarks { get; set; }
            
    		[Display(Name = "序号")]
            [Required]
            [UIHint("EditText")]
    		public  int?  OrderNo { get; set; }
            
        }
	}
}

