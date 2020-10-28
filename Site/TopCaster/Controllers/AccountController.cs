using Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Controllers
{
    public class AccountController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Login(string ReturnUrl = "")
        {
            ViewBag.Message = "";
            ViewBag.ReturnUrl = ReturnUrl;
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User oUser = db.Users.Where(a => a.Username == model.Username && a.Password == model.Password).FirstOrDefault();

                if (oUser != null)
                {
                    Role role = db.Roles.Find(oUser.RoleId);

                    var ident = new ClaimsIdentity(
                      new[] { 
              // adding following 2 claim just for supporting default antiforgery provider
              new Claim(ClaimTypes.NameIdentifier, oUser.Username),
              new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

              new Claim(ClaimTypes.Name,oUser.Username),

              // optionally you could add roles if any
              new Claim(ClaimTypes.Role, role.Name),

                      },
                      DefaultAuthenticationTypes.ApplicationCookie);

                    //HttpContext.GetOwinContext().Authentication.SignIn(
                    //   new AuthenticationProperties { IsPersistent = true }, ident);
                    //



                    HttpContext.GetOwinContext().Authentication.SignIn(
                       new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.Now.AddDays(1) }, ident);
                    return RedirectToLocal(returnUrl, role.Name); // auth succeed 
                }
                else
                {
                    // invalid username or password
                    TempData["WrongPass"] = "Username or Password is incorrect";
                }
            }
            // If we got this far, something failed, redisplay form
            LoginPageViewModel login = new LoginPageViewModel();
            login.login = model;
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);

        }

        private ActionResult RedirectToLocal(string returnUrl, string role)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            //else
            //{
            //    return RedirectToAction("Index", "Users");
            if (role.ToLower().Contains("admin"))
                return RedirectToAction("Index", "users");
            else
                return Redirect("/");
            //}
        }
        public ActionResult LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.SignOut();
            }
            return Redirect("/");
        }

    }
}