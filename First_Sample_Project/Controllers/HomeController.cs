using First_Sample_Project.CustomFilters;
using First_Sample_Project.Models;
using First_Sample_Project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace First_Sample_Project.Controllers
{


    //[Authorize]    
    [CustomAuthorizationFilter]
    public class HomeController : Controller
    {
        private readonly ApplicationUser _applicationUser;
        private readonly IAuthenticationRepository _login;

        public HomeController(ApplicationUser applicationUser,IAuthenticationRepository login)
        {
            _applicationUser = applicationUser;
            _login = login;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region UserDetails
        public IActionResult UserDetails(int? id , string mode="view")
        {
            try
            {
                var user=_login.GetUsersbyId(id);
                if (user != null)
                {
                    ViewBag.Mode=mode;
                    return View("~/Views/Account/Register.cshtml",user);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        #endregion

        public JsonResult JsonDataAction(int id)
        {
            var jsondata = _login.GetUsersbyId(id);
            return Json(jsondata);
        }

        #region DeleteDetails
        //[HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var data=_login.DeleteUser(id);
                if(data==1)
                {
                    return RedirectToAction("ListPage");
                }
                return View();
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        #region ListPageDetails


        public IActionResult ListPage()
        {
            try
            {
                //IEnumerable<UserRegistration> Userlist = _login.GetUsers();
                IEnumerable<UserRegistration> Userlist = _applicationUser.SP_UsersList();

                if (Userlist!=null)
                {
                    return View(Userlist);
                }
                return Problem("Users List is Empty");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region UpdateUsers
        [HttpGet]
        public IActionResult UpdateUser(int? id, string mode = "update")
        {
            try
            {
                var existingusers = _applicationUser.UserRegistration.FirstOrDefault(i => i.Id==id);
                if(existingusers!=null)
                {
                    ViewBag.Mode=mode;

                    return View("~/views/account/register.cshtml",existingusers);
                }
                return Problem("existing users is null");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, UserRegistration user)
        {
            try
            {
                if (id<=0) NotFound();

                
                try
                {
                    _login.UpdateUsers(id, user);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        public IActionResult SearchbyId(int id,string mode="view")
        {
            try
            {
                var user = _login.GetUsersbyId(id);
                ViewBag.Mode=mode;
                return View("~/views/account/register.cshtml", user);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IActionResult StaticWebPage()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            return View();
        }

        public IActionResult Work()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

