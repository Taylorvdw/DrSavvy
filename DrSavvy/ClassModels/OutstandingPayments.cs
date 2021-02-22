using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrSavvy.Models;

namespace DrSavvy.ClassModels
{
    public class OutstandingPayments
    {
        public Patient OwingPatient { get; set; }
        public decimal totalconsultation { get; set; }
        public decimal amountowing { get; set; }
        public int ConID { get; set; }
        public Payment paymentdetails { get; set; }
        public Payment_Type paytype { get; set; }
    }
}