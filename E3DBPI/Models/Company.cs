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
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.AltAddresses = new HashSet<AltAddress>();
            this.Bids = new HashSet<Bid>();
            this.Employees = new HashSet<Employee>();
            this.Orders = new HashSet<Order>();
            this.Projects = new HashSet<Project>();
            this.PaymentMethods = new HashSet<PaymentMethod>();
        }
    
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string WebSite { get; set; }
        public string ContractorLicense { get; set; }
        public string ServiceLevel { get; set; }
        public Nullable<int> BillingCycle { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string CompanyPrimaryImg { get; set; }
        public string CompanySecondaryImg { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyText { get; set; }
        public string ArticleDescription { get; set; }
        public string ArticleText { get; set; }
        public string ResaleCertificate { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UserName { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AltAddress> AltAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }
        public virtual Document Document { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
