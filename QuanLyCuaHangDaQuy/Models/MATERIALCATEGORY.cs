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
    
    public partial class MATERIALCATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATERIALCATEGORY()
        {
            this.ORIGINALITEMs = new HashSet<ORIGINALITEM>();
        }
    
        public string ID { get; set; }
        public string IDUnit { get; set; }
        public string NameMaterial { get; set; }
        public Nullable<double> Profit { get; set; }
    
        public virtual UNIT UNIT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORIGINALITEM> ORIGINALITEMs { get; set; }
    }
}
