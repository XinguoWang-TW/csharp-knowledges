﻿using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System;
using BasicASP.NETMvc.Models;

namespace BasicASP.NETMvc.Controllers
{
    public class AuthController : Controller
    {
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
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
            return RedirectToAction("Index","Movies");
        }

        private void CreateAuthCookie(string userName)
        {
            //basic points 16 please add param into Cookie 
            // use cookie auth
            HttpCookie cookie = new HttpCookie("UseCookies");
            cookie["auth"] = userName;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

        private void AddValusToSession(string userName)
        {
            //basic points 17 Add param into Session and Seeeion key is "userName"
            HttpContext.Session["userName"] = userName;
        }
    }
}