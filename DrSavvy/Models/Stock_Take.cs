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
    
    public partial class Stock_Take
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stock_Take()
        {
            this.Stock_take_Line = new HashSet<Stock_take_Line>();
        }
    
        public int StockTake_ID { get; set; }
        public System.DateTime ST_Date { get; set; }
        public decimal ST_Quantity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock_take_Line> Stock_take_Line { get; set; }
    }
}