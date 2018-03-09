
using PetaPoco;
//*****************************************************************
//
// File Name:   CacheMeta.cs
//
// Description:  Cache:缓存管理表
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
    [MetadataType(typeof(CacheMeta))]
    public partial class CacheModel
    {

        /// <summary>
        /// 充值人姓名英
        /// </summary>
        [ResultColumn("Ssssname")]
        [Display(Name = "用户名")]
        [UIHint("EditText")]
        public string Ssssname { get; set; }


        public partial class CacheMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "缓存键名")]
            [Required]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  CacheKey { get; set; }

            [Display(Name = "缓存值")]
            [UIHint("EditText")]
            [StringLength(500)]
            public string CacheValue { get; set; }
            
    		[Display(Name = "缓存说明")]
            [UIHint("EditText")]
            [StringLength(100)]
    		public  string  Remark { get; set; }
            
    		[Display(Name = "缓存时长秒")]
            [Required]
            [UIHint("EditText")]
            [Range(0,10240000)]
    		public  int?  CacheTimes { get; set; }
            
    		[Display(Name = "是否废弃")]
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
            
    		[Display(Name = "缓存类型")]
            [UIHint("EditText")]
            [StringLength(50)]
    		public  string  CacheType { get; set; }
            
        }
	}
}

