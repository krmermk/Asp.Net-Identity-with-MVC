using IdentityAndBundleConfing.Identity;
using IdentityAndBundleConfing.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IdentityAndBundleConfing.Controllers
{
    public class AccountController : BaseController
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                IdentityResult iResult = userManager.Create(user, model.Password);


                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");
                }
            }

            return View();


        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProps, identity);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("LoginUser", "Böyle bir kullanıcı bulunamadı");
                }

              
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}