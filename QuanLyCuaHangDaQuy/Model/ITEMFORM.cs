//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCuaHangDaQuy.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ITEMFORM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEMFORM()
        {
            this.ITEMS = new HashSet<ITEM>();
        }
    
        public string ID { get; set; }
        public string IDCustomer { get; set; }
        public string IDStaff { get; set; }
        public System.DateTime DateBooking { get; set; }
    
        public virtual INFOCUSTOMER INFOCUSTOMER { get; set; }
        public virtual INFOSTAFF INFOSTAFF { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEMS { get; set; }
    }
}
