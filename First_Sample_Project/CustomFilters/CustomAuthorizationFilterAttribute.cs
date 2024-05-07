using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Security.Claims;

namespace First_Sample_Project.CustomFilters
{
    public class CustomAuthorizationFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var user=context.HttpContext.Session.GetString("User");
            if(user == null)
            {
                context.Result=new RedirectToActionResult("Login", "Account",null);
            }
        }

    }
}
