using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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

    //-----------------------------------------------------------------------------------------------------------
    // Model for RegisterServiceLevel in AccountController
    //-----------------------------------------------------------------------------------------------------------
    public class RegisterServiceLevelViewModel         // Step 2 of registration process - Get their basic Personal and Company Information
    {
        public string ServiceLevel { get; set; }
    }
    //-----------------------------------------------------------------------------------------------------------
    // Model for RegisterSummary in AccountController
    //-----------------------------------------------------------------------------------------------------------
    public class RegisterSummaryViewModel         // Step 2 of registration process - Get their basic Personal and Company Information
    {
        public string UserName { get; set; }

        public string ServiceLevel { get; set; }

        public string BillingFreq { get; set; } 

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email1 { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone1 { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "I have read the Terms and Conditions")]
        [Range (typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms and Conditions to proceed.")]
        public bool Agreed { get; set; }


    }


    //-----------------------------------------------------------------------------------------------------------
    // Model for RegisterEmployee in AccountController
    //-----------------------------------------------------------------------------------------------------------
    public class RegisterEmployeeViewModel         // Step 1 of registration process - Set UserID and Password and create Membership record
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }



    //[System.ComponentModel.DefaultBindingProperty("Checked")]
    //[System.Runtime.InteropServices.ClassInterface]
    //[System.Runtime.InteropServices.ComVisible(true)]
    //[System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDispatch)]
    //public class RadioButton : System.Windows.Forms.ButtonBase


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
