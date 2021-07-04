using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMDJMS.Common.Basic.Exception;
using KMDJMS.Common.Dto.User;
using KMDJMS.Common.Service.Common.Log;
using KMDJMS.Common.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KMDJMS.WebAPI.Common.Controllers.User
{
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Api/User/Login")]
        public IActionResult Login(string phone, string password)
        {
            try
            {
                var sessionId = HttpContext.Session.Id;
                BriefUser briefUser = _userService.Login(phone, password, sessionId);

                if (briefUser == null)
                {
                    return Json(new
                    {
                        code = -1,
                        msg = "fail"
                    });
                }
                else
                {
                    return Json(new
                    {
                        code = 0,
                        data = briefUser
                    });
                }
            }
            catch (WebApiException ex)
            {
                LogHelper.Info(ex);

                return Json(new
                {
                    code = -1,
                    msg = ex.Message
                });
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                return Json(new
                {
                    code = -99,
                    msg = "System Error"
                });
            }
        }

        [HttpPost]
        [Route("Api/User/GetList")]
        public IActionResult GetList([FromBody]GetUserListSo request)
        {
            try
            {
                var sessionId = HttpContext.Session.Id;
                var briefUsers = _userService.GetList(request);

                if (briefUsers == null)
                {
                    return Json(new
                    {
                        code = -1,
                        msg = "fail"
                    });
                }
                else
                {
                    return Json(new
                    {
                        code = 0,
                        data = briefUsers
                    });
                }
            }
            catch (WebApiException ex)
            {
                LogHelper.Info(ex);

                return Json(new
                {
                    code = -1,
                    msg = ex.Message
                });
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                return Json(new
                {
                    code = -99,
                    msg = "System Error"
                });
            }
        }
    }
}
