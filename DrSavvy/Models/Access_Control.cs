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
    
    public partial class Access_Control
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Access_Control()
        {
            this.Employee_Role = new HashSet<Employee_Role>();
        }
    
        public int AccessID { get; set; }
        public string AC_Name { get; set; }
        public string AC_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Role> Employee_Role { get; set; }
    }
}