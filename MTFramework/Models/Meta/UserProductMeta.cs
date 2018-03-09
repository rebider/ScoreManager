
//*****************************************************************
//
// File Name:   UserProductMeta.cs
//
// Description:  UserProduct:
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
    [MetadataType(typeof(UserProductMeta))]
    public partial class UserProductModel
    {
        public partial class UserProductMeta
        {
    		[Display(Name = "")]
            [Required]
            [UIHint("EditText")]
            public  string  ID { get; set; }
            
    		[Display(Name = "")]
            [UIHint("EditText")]
    		public  int?  ProductId { get; set; }
            
    		[Display(Name = "")]
            [UIHint("EditText")]
    		public  int?  UserId { get; set; }
            
        }
	}
}

