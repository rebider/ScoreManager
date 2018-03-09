
//*****************************************************************
//
// File Name:   FileMeta.cs
//
// Description:  File:
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
    [MetadataType(typeof(FileMeta))]
    public partial class FileModel
    {
        public partial class FileMeta
        {
    		[Display(Name = "主键")]
            [Required]
            [UIHint("EditText")]
            public  string ID { get; set; }
            
    		[Display(Name = "文件物理路径")]
            [UIHint("EditText")]
            [StringLength(200)]
    		public  string  PathName { get; set; }
            
    		[Display(Name = "文件显示名称")]
            [UIHint("EditText")]
            [StringLength(200)]
    		public  string  ShowName { get; set; }
            
    		[Display(Name = "创建时间")]
            [UIHint("EditText")]
    		public  DateTime?  CreateTime { get; set; }
            
        }
	}
}

