using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallCodeBoot.Models;
using SmallCodeBoot.Extendsions;
using SmallCodeBoot.Helpers.EFFilter;

namespace SmallCodeBoot.Services
{
    public class UserService : BaseService
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


        public List<User> GetUserPage(List<WhereFilter> filters, int pageIndex, int pageSize, out int total)
        {
            int index = (pageIndex - 1) * pageSize;
            using (SmallCodeContext db = new SmallCodeContext())
            {
                total = db.Users.GenerateFilter(filters).Count();
                return db.Users.GenerateFilter(filters).Skip(index).Take(pageSize).ToList();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="user"></param>
        public  void Save(User user)
        {
            using (SmallCodeContext db = new SmallCodeContext())
            {
                db.Users.Add(user);
                bool result = db.SaveChanges() > 0;
                base.IsSuccess = result;
                base.ReturnMsg = result ? "保存成功" : "保存失败";
            }
        }

        /// <summary>
        /// 分页得到用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public void GetList(string username, int pageIndex, int pageSize)
        {
            var totalRecords = 0;
            using (SmallCodeContext db = new SmallCodeContext())
            {
                string sql = "exec SP_Query_GetUserList  @P0,@P1,@P2";
                // 参数设定
                object[] param = { username, pageIndex, pageSize };
                base.PageTable = db.ExecuteDataTableForPager(sql, ref totalRecords, param);
                base.TotalRecords = totalRecords;
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

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="newPassword"></param>
        public void UpdatePassword(Guid ID, string newPassword, string oldPassword)
        {
            using (SmallCodeContext db = new SmallCodeContext())
            {
                User user = db.Users.Find(ID);

                if (user.Password != oldPassword.ToMD5Hash())
                {
                    base.IsSuccess = false;
                    base.ReturnMsg = "原始密码不正确";
                }
                else
                {
                    user.Password = newPassword.ToMD5Hash();
                    bool result = db.SaveChanges() > 0;
                    base.IsSuccess = result;
                    base.ReturnMsg = result ? "修改成功" : "修改失败";
                }
            }
        }
    }
}