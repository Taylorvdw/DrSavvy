using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrSavvy.Models;

namespace DrSavvy.ClassModels
{
    public class ProductCombine
    {
        public Product prodlist { get; set; }
        public Product_Type prodtypelist { get; set; }
    }
}