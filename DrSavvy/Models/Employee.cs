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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Users = new HashSet<User>();
        }
    
        public int EMP_ID { get; set; }
        public string EMPName { get; set; }
        public string EMPSurname { get; set; }
        public string EMP_CellphoneNum { get; set; }
        public string EMP_Email { get; set; }
        public string Emp_IDNum { get; set; }
        public Nullable<int> EMP_Role_ID { get; set; }
    
        public virtual Employee_Role Employee_Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}