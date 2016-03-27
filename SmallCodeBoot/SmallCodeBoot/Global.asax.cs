using SmallCodeBoot.Helpers;
using SmallCodeBoot.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmallCodeBoot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ///跟页面提交的东西相关
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            InitDataBase();

        }

        private static void InitDataBase()
        {
            //数据库不存在时创建
            Database.SetInitializer(new CreateDatabaseIfNotExists<SmallCodeContext>());

            //初始化数据
            Database.SetInitializer(new InitData());
        }



    }
}
