//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DrSavvy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Institute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Institute()
        {
            this.Referral_Test = new HashSet<Referral_Test>();
        }
    
        public int Institute_ID { get; set; }
        public string Institute_Name { get; set; }
        public int Institute_Type_ID { get; set; }
        public string Institute_ContactPerson { get; set; }
        public string Instsitute_ContactNumber { get; set; }
    
        public virtual Institute_Type Institute_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referral_Test> Referral_Test { get; set; }
    }
}
