﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPresntationLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MVCPresntationLayer.Controllers
{
    [Authorize(Roles = "Island Owner")]
    public class AdminController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager userManager;

        // GET: Admin
        public ActionResult Index()
        {
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return View(userManager.Users.OrderBy(n => n.CharacterName).ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser applicationUser = userManager.FindById(id);

            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            // get a list of roles the user has and put them into a viewbag as roles
            // along with a list of roles the user doesn't have as noRoles
            var usrMgr = new LogicLayer.UserManager();
            var allRoles = usrMgr.GetAllRoles();

            var roles = userManager.GetRoles(id);
            var noRoles = allRoles.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View(applicationUser);
        }       

        public ActionResult RemoveRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            // code to prevent removing the last administrator 
            if (role.Equals("Island Owner"))
            {
                var adminUsers = userManager.Users.ToList()
                    .Where(u => userManager.IsInRole(u.Id, "Island Owner"))
                    .ToList().Count();
                if(adminUsers < 2)
                {
                    ViewBag.Error = "Cannot remove last Island Owner.";
                }
            }
            userManager.RemoveFromRole(id, role);            

            if(user.VillagerID != null)
            {
                try
                {
                    var usrMgr = new LogicLayer.UserManager();
                    usrMgr.DeleteUserRole((int)user.VillagerID, role);
                }
                catch (Exception)
                {
                    // nothing to do
                }
            }
            
            return RedirectToAction("Details", "Admin", new { id = user.Id });
        }

        public ActionResult AddRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            userManager.AddToRole(id, role);

            if(user.VillagerID != null)
            {
                try
                {
                    var usrMgr = new LogicLayer.UserManager();
                    usrMgr.AddUserRole((int)user.VillagerID, role);
                } catch(Exception)
                {
                    // nothing to do
                }
            }
            return RedirectToAction("Details", "Admin", new { id = user.Id });
        }
    }
}
