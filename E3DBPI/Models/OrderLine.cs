//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E3DBPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderLine
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> ItemQty { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> LineTotal { get; set; }
        public string OrderLineStatus { get; set; }
        public string ThumbImage { get; set; }
        public Nullable<int> BoxID { get; set; }
        public bool Fullfilled { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Size { get; set; }
        public Nullable<int> Color { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
