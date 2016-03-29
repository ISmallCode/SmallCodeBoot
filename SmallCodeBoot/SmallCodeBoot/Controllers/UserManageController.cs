using SmallCodeBoot.DataModels;
using SmallCodeBoot.Extendsions;
using SmallCodeBoot.Helpers.EFFilter;
using SmallCodeBoot.Models;
using SmallCodeBoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallCodeBoot.Controllers
{
    public class UserManageController : BaseController
    {
        UserService service = new UserService();
        // GET: UserManage
        public ActionResult Index(string Username = "", int pageIndex = 1, int pageSize = 10)
        {
            return View();
        }


        public PartialViewResult UserList(string Username = "", int pageIndex = 1, int pageSize = 10)
        {
            service.GetList(Username, pageIndex, pageSize);
            return PartialView(new BaseViewModel { TotalRecords = service.TotalRecords, DataSource = service.PageTable });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            AjaxReturnModel model = new AjaxReturnModel();
            user.CreatedDate = DateTime.Now;
            user.Password = user.Password.ToMD5Hash();
            user.ID = Guid.NewGuid();
            user.IsDelete = false;
            service.Save(user);
            model.Status = service.IsSuccess ? "ok" : "fail";
            model.ReturnUrl = "/UserManage";
            model.Message = service.ReturnMsg;
            return Json(model);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            AjaxReturnModel model = new AjaxReturnModel();
            service.Remove(id);
            model.Status = service.IsSuccess ? "ok" : "fail";
            model.Message = service.ReturnMsg;
            return Json(model);
        }
    }
}