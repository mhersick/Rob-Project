using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E3DBPI.Models
{
    // these are the fields defined in home/Contact.cshtml
    public class SendContactViewModel
    {
        [Required]                                                                  // required field
        [DataType(DataType.EmailAddress)]                                           // set datatype as email
        [Display(Name = "Email")]
        public string Email { get; set; }                                           // get the user entered email address

        [Required]                                                                  // required field
        [Display(Name = "First Name")]
        public string fname { get; set; }                                           // get the user enterd name

        [Required]                                                                  // required field
        [Display(Name = "Last Name")]
        public string lname { get; set; }                                           // get the user enterd name

        [Required]                                                                  // required field
        [Display(Name = "Company")]
        public string company { get; set; }                                           // get the user enterd name

        [Display(Name = "Phone")]
        public string phone1 { get; set; }                                           // get the user enterd name

        [Display(Name = "Interest")]
        public string category { get; set; }                                           // get the user enterd name

        [Required]                                                                  // required field
        [Display(Name = "Comment")]
        public string comment { get; set; }                                           // get the user enterd name

    }
}