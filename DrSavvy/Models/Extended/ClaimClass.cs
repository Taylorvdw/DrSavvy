using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{
    public class ClaimClass
    {
        public int Medical_Aid_Claim_ID { get; set; }
        public decimal Claim_Amount { get; set; }
        public System.DateTime Claim_Date { get; set; }
        public string Claim_Description { get; set; }
        public Nullable<int> Payment_ID { get; set; }
        public int Consultation_ID { get; set; }
        public string ClaimStatus { get; set; }
    }
}