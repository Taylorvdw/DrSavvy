using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{
    public class ProductClass
    {
        public int ProductID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Product Name")]
        public string ProductName { get; set; }
       
        public decimal Product_Qty { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Select Product Type")]
        public int Product_Type_ID { get; set; }
        
        public bool Product_Disable { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Select Supplier Name")]
        public Nullable<int> Supplier_ID { get; set; }
        
        public string SupplierName { get; set; }
        
        public string Product_Type_Description { get; set; }
        public Nullable<decimal> Price_Figure { get; set; }
    }
}