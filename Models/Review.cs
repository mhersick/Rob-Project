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
    
    public partial class Review
    {
        public int ReviewID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public Nullable<int> StarRate { get; set; }
        public string ReviewText { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Featured { get; set; }
    }
}
