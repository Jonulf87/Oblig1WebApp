using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1Vy.Controllers
{
    [Authorize(Roles = "admins")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVm login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                var user = userManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var identity = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    

                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, identity);
                    
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Feil brukernavn eller passord");

            return View(login);
        }
    }
}