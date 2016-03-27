using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallCodeBoot.Models;

namespace SmallCodeBoot.Services
{
    public class UserService
    {

        /// <summary>
        /// 根据用户名得到用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            using (SmallCodeContext db = new SmallCodeContext())
            {
                return db.Users.Where(x => x.Username == name).FirstOrDefault();
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string username, string password)
        {
            using (SmallCodeContext db = new SmallCodeContext())
            {
                return db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            }
        }
    }
}