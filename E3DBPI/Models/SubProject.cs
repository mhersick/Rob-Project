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
    using System.ComponentModel.DataAnnotations;

    public partial class SubProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubProject()
        {
            this.Bids = new HashSet<Bid>();
            this.Documents = new HashSet<Document>();
        }
    
        public int SubProjectID { get; set; }
        public int ProjectID { get; set; }
        public string SubProjectName { get; set; }
        public string SubProjectDescription { get; set; }
        public int SubProjectStatus { get; set; }
        public int ProjectCategory { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> OpenDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> BiDOpenDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> BidCloseDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<int> AcceptedBid { get; set; }
        public Nullable<int> AcceptedCompany { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> ActionDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<int> Dependencies { get; set; }
        public Nullable<int> BidStatus { get; set; }
        public bool IsSubProject { get; set; }
        public Nullable<int> SubProjectOf { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
        public virtual Project Project { get; set; }
    }
}
