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
    
    public partial class Referral
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Referral()
        {
            this.Referral_Test = new HashSet<Referral_Test>();
        }
    
        public int Ref_ID { get; set; }
        public string Comment { get; set; }
        public int Consultation_ID { get; set; }
    
        public virtual Consultation Consultation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referral_Test> Referral_Test { get; set; }
    }
}
