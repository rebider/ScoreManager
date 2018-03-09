
//*****************************************************************
//
// File Name:   ConfigMeta.cs
//
// Description:  Config:系统配置表
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
    [MetadataType(typeof(ConfigMeta))]
    public partial class ConfigModel
    {
        public partial class ConfigMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "配置名")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  ConfigKey { get; set; }
            
    		[Display(Name = "配置值")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  ConfigData { get; set; }
            
    		[Display(Name = "配置类型")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  ConfigType { get; set; }
            
    		[Display(Name = "是否废弃 1：是； 0 ：否（默认0）")]
            [Required]
            [UIHint("EditDelFlagList")]
            [Range(0,10240000)]
    		public  int?  DelFlag { get; set; }
            
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

