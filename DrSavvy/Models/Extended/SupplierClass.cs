using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{
    public class SupplierClass
    {
        public int Supplier_ID { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage = "Enter Company Name")]
        public string SupplierName { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string SupplierEmail { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage = "Enter Supplier Address")]
        public string SupplierAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Product Type Name")]
        public string SupplierContactPerson { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Product Type Name")]
        public string SupplierCellNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Product Type Name")]
        public string SupplierWorkNumber { get; set; }
    }
}