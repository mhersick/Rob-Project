using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E3DBPI.ViewModels
{
    // not used right now
    public class CompanyEditViewModel
    {
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
        public string CompanyPrimaryImg { get; set; }
        public string CompanySecondaryImg { get; set; }
        public string CompanyDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string CompanyText { get; set; }
        public string ArticleDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string ArticleText { get; set; }
        public string ResaleCertificate { get; set; }
    }
}