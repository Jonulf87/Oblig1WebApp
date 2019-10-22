using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1Vy.Model.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;


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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
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
                    var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Feil brukernavn eller passord.");

            return View(login);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult CreateStation()
        {
            return View();
        }

        public ActionResult ReadStation()
        {
            return View();
        }

        public ActionResult UpdateStation()
        {
            return View();
        }

        public ActionResult DeleteStation()
        {
            return View();
        }
    }
}