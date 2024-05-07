using First_Sample_Project.CustomFilters;
using First_Sample_Project.Models;
using First_Sample_Project.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace First_Sample_Project.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAuthenticationRepository _login;
        private readonly ApplicationUser _applicationUser;

        private readonly IHttpContextAccessor _contextaccessor;
        public AccountController(ApplicationUser applicationUser, IAuthenticationRepository login, IHttpContextAccessor contextaccessor)
        {
            _applicationUser=applicationUser;
            _login=login;
            _contextaccessor=contextaccessor;
        }

        [HttpGet]
        public IActionResult Register(string mode="submit")
        {
            try
            {
                ViewBag.Mode=mode;
                return View("~/Views/Account/Register.cshtml");
            }
            catch(Exception)
            {
                throw;
            }
        }

        
        [HttpPost]
        public IActionResult Register(UserRegistration user)
        {
            try
            {
                
                var Isvalid = _login.AddUsers(user);
                if (Isvalid==1)
                {
                    ViewBag.Message="Welcome "+user.Email+ " Registered successfully";
                    return View("~/Views/Account/Login.cshtml");
                }
                return View();
                
            
            }
            catch(Exception)
            {
                throw;
            }
        }


     

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            try
            {
                return View("~/Views/Account/Login.cshtml");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Login(string? email, string? password)
        {
            try
            {
                if (email!=null && password!=null)
                {
                    bool isSuccess = _login.AuthenticatedUser(email, password);

                    if (isSuccess)
                    {
                        var session = _contextaccessor.HttpContext.Session;
                        session.SetString("User", "Valid");

                        TempData["email"]=email;
                        ViewBag.LoginMessage="";
                        return RedirectToAction("ListPage","Home");
                    }
                    else
                    {
                        //ViewBag.ErrorBoldmsg="ERROR";
                        ViewBag.LoginMessage=string.Format("ERROR: Incorrect username or password.", email);
                        return View();
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login","Account");
        }

    }
}


