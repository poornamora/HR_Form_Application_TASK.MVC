using First_Sample_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace First_Sample_Project.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationUser _context;

        private readonly IWebHostEnvironment _webhostbuilder;
        public AuthenticationRepository(ApplicationUser context, IWebHostEnvironment webhostbuilder)
        {
            _context = context;
            _webhostbuilder = webhostbuilder;
        }

        #region Authentication
        public bool AuthenticatedUser(string? email, string? password)
        {
            try
            {
                var succeed = _context.UserRegistration.Where(a => a.Email==email &&  a.Password==password).FirstOrDefault(i => i.IsActive==true);

                if (succeed!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetUsers
        public IEnumerable<UserRegistration> GetUsers()
        {
            try
            {
                var userlist = _context.UserRegistration.ToList();
                var result = from users in userlist
                             where users.IsActive==true
                             select users;

                //var output1 = from user1 in userlist.Where(i => i.Id==10) select user1;

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        #region AddUsers
        public int AddUsers(UserRegistration user)
        {
            try
            {
                UserRegistration userobj = new UserRegistration();
                userobj.Name = user.Name;
                userobj.Email = user.Email;
                userobj.Password = user.Password;
                //userobj.ConformPassword=user.ConformPassword;
                _context.UserRegistration.Add(userobj);
                var success = _context.SaveChanges();

                return (success!=0) ? 1 : 0;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete Users
        public int DeleteUser(int id)
        {
            try
            {
                if (id>0)
                {
                    var userdetails = _context.UserRegistration.FirstOrDefault(i => i.Id==id);
                    if (userdetails!=null)
                    {
                        _context.UserRegistration.Remove(userdetails);
                        var rowaffected = _context.SaveChanges();
                    }
                    return 1;
                }
                return 0;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
        #endregion

        #region Update Users
        public void UpdateUsers(int id, UserRegistration user)
        {
            try
            {
                if (id!=0 && user!=null)
                {

                    var existedusers = _context.UserRegistration.FirstOrDefault(i => i.Id== id);

                    if (existedusers!=null)
                    {
                        existedusers.Name = user.Name;
                        existedusers.Email = user.Email;
                        existedusers.Password = user.Password;
                        _context.SaveChanges();
                    }
                }
               
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        #region UserDetailsbyID
        public UserRegistration GetUsersbyId(int? id)
        {
            try
            {
                var user = GetUsers().FirstOrDefault(i => i.Id==id);
                if (user!=null)
                {
                    return user;
                }
                return user;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}

