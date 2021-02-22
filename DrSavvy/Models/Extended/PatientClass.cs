using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrSavvy.Models
{
    public class PatientClass
    {
        public int Patient_ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Patient Name")]
        public string PatientName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Patient Surname")]
        public string PatientSurname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Patient Cellphone Number")]
        public string PatientCell { get; set; }
        public string PatientWorkNum { get; set; }
        public string PatientTelNum { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PatientEmail { get; set; }
        public string PatientPoBox { get; set; }
        public string PatientHomeAddress { get; set; }
        
        public string PatientIDNum { get; set; }
        public string MedicalAidNo { get; set; }
        public Nullable<int> DependentNo { get; set; }
        public string DepName { get; set; }
        public Nullable<int> Scheme_ID { get; set; }
        public string Company_Name { get; set; }
        public string Scheme_Name { get; set; }
        public Nullable<int> Title_ID { get; set; }
        public string Title_Description { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public IEnumerable<Allergy> GetAlergyList { get; set; }
        public int Allergy_ID { get; set; }
        
        public IEnumerable<Medical_Aid_Scheme> GetSchemeList { get; set; }
        public int[] Alergylist { get; set; }
        public int Company_ID { get; set; }
        public string DepSurname { get; set; }
        public IEnumerable<Patient> GetSurnameList { get; set; }
        public string depIDNum { get; set; }

    }
}