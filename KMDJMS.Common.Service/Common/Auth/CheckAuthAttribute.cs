using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMDJMS.Common.Basic.Enum;
using KMDJMS.Common.Basic.Exception;
using KMDJMS.Common.Repository.DbContext;
using KMDJMS.Common.Service.Common.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KMDJMS.Common.Service.Common.Auth
{
    public class CheckAuthAttribute : ActionFilterAttribute
    {
        private BasicDbContext _basicDbContext { get; set; }
        public int UserRoleAuth;

        public CheckAuthAttribute(int userRoleAuth = 0)
        {
            UserRoleAuth = userRoleAuth;
        }

        public CheckAuthAttribute(BasicDbContext basicDbContext)
        {
            _basicDbContext = basicDbContext;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            

            try
            {
                string token = context.HttpContext.Request.Headers[CookieEnum.KMDJToken.ToString()];
                string userIdStr = context.HttpContext.Request.Headers[CookieEnum.KMDJUser.ToString()];

                //User Info
                var userToken = _basicDbContext.UserTokens.FirstOrDefault(t => t.Token == token);

                if (userToken == null || string.IsNullOrEmpty(userIdStr))
                {
                    throw new WebApiException("Login info error");
                }

                var userId = long.Parse(userIdStr);

                if (userToken.UserId != userId)
                {
                    throw new WebApiException("user token not match");
                }

                var user = _basicDbContext.Users.FirstOrDefault(t => t.UserId == userId);

                if (user == null)
                {
                    throw new WebApiException("user not exists");
                }

                AuthInfo.SetRequestAuthInfo(user);

                var isPass = CheckAuthorityByToken(context, user);

                if (!isPass)
                {
                    var jsonResult = new JsonResult(new {code = -1, msg = "Login error or No authority"});
                    context.HttpContext.Response.ContentType = "application/json";
                    context.Result = jsonResult;
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                var jsonResult = new JsonResult(new { code = -1, msg = "Login error" });
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = jsonResult;
                return;
            }
            
        }

        public bool CheckAuthorityByToken(ActionExecutingContext context, Model.User.User user)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var url = $"api/{context.ActionDescriptor.RouteValues["controller"]}/{context.ActionDescriptor.RouteValues["action"]}";

            //if (controllerActionDescriptor?.MethodInfo.GetCustomAttributes(typeof(CheckAuthAttribute), true) != null)
            //{

            //}

            if (((int)user.UserRole & UserRoleAuth) != 1)
            {
                return false;
            }

            return true;
        }
    }
}
