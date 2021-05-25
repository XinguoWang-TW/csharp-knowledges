using Microsoft.AspNetCore.Mvc;
using System;
using BasicASP.NETMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BasicASP.NETMvc.Controllers
{
    public class AuthController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user == null || !"admin".Equals(user.UserName) || !"admin".Equals(user.PassWord))
            {
                ViewBag.Error = "UserName and PassWord is admin";
                return View();
            }

            CreateAuthCookie(user.UserName);
            AddValusToSession(user.UserName);
            return RedirectToAction("Page");
        }


        //basic points 14 please make sure this action should be authed.
        [Authorize]
        public ActionResult Page()
        {
            // # homework 1 -- redirect to movies/index
            ViewBag.UserNameSession = HttpContext.Session.GetString("userName");
            return RedirectToAction("Index","Movies");
        }

        private void CreateAuthCookie(string userName)
        {
            //basic points 16 please add param into Cookie 
            // use cookie auth
            Response.Cookies.Append("auth", userName, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30)
            });
        }

        private void AddValusToSession(string userName)
        {
            //basic points 17 Add param into Session and Seeeion key is "userName"
            HttpContext.Session.SetString("userName", userName);
        }
    }
}