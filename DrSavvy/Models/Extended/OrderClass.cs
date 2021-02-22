 
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{
    public class OrderClass
    {
        public int OrderID { get; set; }
        public decimal Order_Cost { get; set; }
        public int OS_ID { get; set; }
        public int Supplier_ID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Order_Date { get; set; }
        public string OS_Description { get; set; }
        public string SupplierName { get; set; }
        public Nullable<bool> PaidStatus { get; set; }
        public decimal Prod_Qty { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal AmountPaid { get; set; }
    }
}