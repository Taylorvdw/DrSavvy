using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrSavvy.Models;

namespace DrSavvy.Models
{
    public class AllergiesList
    {
        List<Patient> Patient { get; set; }
        List<Patient_Allergy_List> Allergyl {get;set;}

        List<Allergy> Allergy { get; set; }
    }
}