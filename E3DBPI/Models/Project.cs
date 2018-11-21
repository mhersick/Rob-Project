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

    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.SubProjects = new HashSet<SubProject>();
        }
    
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectStatus { get; set; }
        public int ProjectCategory { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> OpenDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> BidOpenDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> BidCloseDate { get; set; }
        public int CompanyID { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> CompletionDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<int> AcceptedBid { get; set; }
        public Nullable<int> AcceptedCompany { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> ActionDate { get; set; }
        public string SiteAddress1 { get; set; }
        public string SiteAddress2 { get; set; }
        public string SiteAddressCity { get; set; }
        public string SiteAddressState { get; set; }
        public string SiteAddressZip { get; set; }
        public string SiteAddressCountry { get; set; }
        public bool IsSubProject { get; set; }
        public Nullable<int> SubProjectOf { get; set; }
        public Nullable<int> BidStatus { get; set; }
        public Nullable<int> Dependencies { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubProject> SubProjects { get; set; }
    }
}
