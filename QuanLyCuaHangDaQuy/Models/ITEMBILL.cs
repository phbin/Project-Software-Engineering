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
    
    public partial class ITEMBILL
    {
        public string ID { get; set; }
        public string IDItemBillForm { get; set; }
        public string IDItem { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual IMPORTEDITEM IMPORTEDITEM { get; set; }
        public virtual ITEMBILLFORM ITEMBILLFORM { get; set; }
    }
}
