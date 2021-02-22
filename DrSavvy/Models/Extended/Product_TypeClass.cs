using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{

    //[MetadataType(typeof(Product_TypeMetadata))]
    public partial class Product_TypeClass
    {
        public int Product_Type_ID { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage = "Enter Product Type Name")]
        public string Product_Type_Description { get; set; }


    }
    //public class Product_TypeMetadata
    //{
    //    [Required(AllowEmptyStrings =false, ErrorMessage ="Please provide Product Type Name")]
    //    public string Product_Type_Description { get; set; }
    //}
}