using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FGMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FGMS.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        public AdminController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Name = new SelectList(context.Roles);
                ViewBag.User = new SelectList(context.Users);

                return RedirectToAction("Index", "Users");

            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary> 
        /// Create  a New role 
        /// </summary> 
        /// <returns></returns> 
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary> 
        /// Create a New Role 
        /// </summary> 
        /// <param name="Role"></param> 
        /// <returns></returns> 
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}