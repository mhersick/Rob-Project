using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E3DBPI.Models;
using Microsoft.AspNet.Identity;

namespace E3DBPI.Controllers
{
    public class BaseController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Base
        public ActionResult Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();

            //-----------------------------------------------------------------------------------------------------------
            // Get Employee and Company data using the UserName of a authenticated user
            //-----------------------------------------------------------------------------------------------------------
            SiteDBEntities db = new SiteDBEntities();

            var empq = db.Employees.FirstOrDefault(e => e.UserName == userName);
            var eIDz = empq.EmployeeID;

            var eIDx = db.Employees.FirstOrDefault(e => e.EmployeeID == eIDz);
            ViewBag.eIDx = eIDx.EmployeeID;
            ViewBag.cIDx = eIDx.CompanyID;
            ViewBag.fName = eIDx.FirstName;
            ViewBag.lName = eIDx.LastName;

            var cIDx = db.Companies.FirstOrDefault(e => e.CompanyID == eIDx.CompanyID);
            //ViewBag.cIDx = cIDx;
            ViewBag.co_cName = cIDx.CompanyName + " - ";

            return View();
        }
    }
}