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
    
    public partial class FORMCATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORMCATEGORY()
        {
            this.ORIGINALITEMs = new HashSet<ORIGINALITEM>();
        }
    
        public string ID { get; set; }
        public string NameForm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORIGINALITEM> ORIGINALITEMs { get; set; }
    }
}
