//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCuaHangDaQuy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INFOCUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFOCUSTOMER()
        {
            this.CUSSERVICEs = new HashSet<CUSSERVICE>();
            this.ITEMFORMs = new HashSet<ITEMFORM>();
        }
    
        public string ID { get; set; }
        public string FullName { get; set; }
        public System.DateTime DoB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long IDPersonal { get; set; }
        public Nullable<int> Points { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSSERVICE> CUSSERVICEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMFORM> ITEMFORMs { get; set; }
    }
}
