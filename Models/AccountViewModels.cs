﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using E3DBPI.Models;
using System.Linq;
using System.Web;
using System.Text;

namespace E3DBPI.Models
{



        // these are the fields defined in SendEmail.cshtml
        public class SendEmailViewModel
    {
        [Required]                                                                  // required field
        [Display(Name = "First Name")]
        public string fname { get; set; }                                           // get the user enterd name

        [Required]                                                                  // required field
        [DataType(DataType.EmailAddress)]                                           // set datatype as email
        [Display(Name = "Email")]
        public string Email { get; set; }                                           // get the user entered email address

    }

    // this is for 2-factor email confirmation
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        //[EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //-----------------------------------------------------------------------------------------------------------
    // Model for Register in AccountController
    //-----------------------------------------------------------------------------------------------------------
    public class RegisterViewModel         // Step 1 of registration process - Set UserID and Password and create Membership record
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    //-----------------------------------------------------------------------------------------------------------
    // Model for RegisterStep2 in AccountController
    //-----------------------------------------------------------------------------------------------------------
    public class RegisterStep2ViewModel         // Step 2 of registration process - Get their basic Personal and Company Information
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone1 { get; set; }


        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }


    public class RegisterServiceLevelViewModel         // Step 2 of registration process - Get their basic Personal and Company Information
    {
        public string ServiceLevel { get; set; }

    }


        public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
