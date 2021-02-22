using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrSavvy.Models;

namespace DrSavvy.ClassModels
{
    public class MedicalCertificateModel
    {
        public Sick_Note sicknotelist { get; set; }
        public Consultation ConList { get; set; }
        public Patient PatientList { get; set; }
        public Consultation_Ailment Con_Ailment { get; set; }
       // public Ailment ailmnt { get; set; }
        public Appointment appointmentlist { get; set; }
    }
}