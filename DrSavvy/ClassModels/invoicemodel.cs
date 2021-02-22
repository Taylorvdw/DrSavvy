using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrSavvy.Models;

namespace DrSavvy.ClassModels
{
    public class invoicemodel
    {
        public Product_Procedure product_procedure { get; set; }
        public Product product { get; set; }
        public Price price { get; set; }
        public Procedure procedure { get; set; }
        public Consultation consultation { get; set; }
        public Consultation_Procedure consultation_procedure { get; set; }

    }
}