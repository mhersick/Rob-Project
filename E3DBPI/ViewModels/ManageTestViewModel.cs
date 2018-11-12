using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using E3DBPI.Models;

namespace E3DBPI.ViewModels
{
    public class ManageTestViewModel
    {

        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public bool EmailConfirmed { get; set; }

        // private SiteDBEntities db = new SiteDBEntities();

        public IEnumerable<Employee> Employee { get; set; }
        public int EmployeeID { get; set; }     // get EmployeeID from the Employee table.  The index is username
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Employee> Company { get; set; }
        public int CompanyID { get; set; }      // get CompanyID from the Company table.  The index is username


    }




}