using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SmallCodeBoot.Extendsions;
using SmallCodeBoot.Models;
using SmallCodeBoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SmallCodeBoot.Controllers
{
    public class AccountController : BaseController
    {

        UserService service = new UserService();

        /// <summary>
        ///  授权属性
        /// </summary>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 执行登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("warn", "用户名或者密码不能为空");
            }
            else
            {
                Password = Password.ToMD5Hash();
                User user = service.Login(Username, Password);
                if (user == null)
                {
                    ModelState.AddModelError("warn", "用户名或者密码错误");
                }
                else
                {
                    ClaimsIdentity ci = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                    ci.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    ci.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

                    AuthenticationManager.SignIn(ci);

                    return Redirect("/Home/Index");
                }
            }
            return View();
        }

        /// <summary>
        /// 注销登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }


        public ActionResult Show()
        {
            return View(CurrentUser);
        }
    }
}