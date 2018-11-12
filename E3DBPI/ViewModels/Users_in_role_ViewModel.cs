using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E3DBPI.ViewModels
{

    //-----------------------------------------------------------------------------------------------------------
    // Model to display list of Users and their roles
    //-----------------------------------------------------------------------------------------------------------
    public class Users_in_role_ViewModel
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Role { get; set; }
    }

}