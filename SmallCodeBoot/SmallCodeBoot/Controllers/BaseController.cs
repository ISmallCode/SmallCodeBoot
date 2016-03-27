using SmallCodeBoot.Helpers;
using SmallCodeBoot.Models;
using SmallCodeBoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmallCodeBoot.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public User CurrentUser { set; get; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                UserService service = new UserService();
                CurrentUser = service.GetUserByName(User.Identity.Name.Trim());
            }
            ViewBag.CurrentUser = CurrentUser;
        }

        /// <summary>
        /// 在Action之前
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Log log = new Log
            {
                Ip = IPHelper.GetIPAddress(),
                CreateDate = DateTime.Now,
                Description = "访问出现异常",
                Exception = filterContext.Exception.Message,
                Level = LogType.异常
            };
            LogService service = new LogService();
            service.Save(log);
            base.OnException(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}