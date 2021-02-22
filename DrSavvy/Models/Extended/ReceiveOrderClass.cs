using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{
    public class ReceiveOrderClass
    {
        public int OrderLineID { get; set; }
        public decimal Prod_Qty { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}