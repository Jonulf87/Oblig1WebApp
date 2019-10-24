using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Oblig1Vy;
using Oblig1Vy.DAL;
using Oblig1Vy.DAL.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace Oblig1Vy
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new Oblig1Context());
            app.CreatePerOwinContext<UserManager<IdentityUser>>((options, context) =>
                new UserManager<IdentityUser>(
                    new UserStore<IdentityUser>(new Oblig1Context())));

            app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) =>
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new Oblig1Context())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Login"),
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(60)
            });
        }
    }
}