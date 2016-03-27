using SmallCodeBoot.Extendsions;
using SmallCodeBoot.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.Helpers
{
    public class InitData : CreateDatabaseIfNotExists<SmallCodeContext>
    {
        protected override void Seed(SmallCodeContext context)
        {
            new List<User>
            {
                new User
                {
                    ID =new Guid(),
                    Username="admin",
                    Password = "123456".ToMD5Hash(),
                   CreatedDate=DateTime.Now,
                   Role=Role.超级管理员,
                   IsDelete=false
                }
            }.ForEach(m => context.Users.Add(m));
        }
    }
}