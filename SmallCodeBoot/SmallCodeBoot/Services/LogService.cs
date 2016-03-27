using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallCodeBoot.Models;

namespace SmallCodeBoot.Services
{
    public class LogService : BaseService
    {
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="log"></param>
        public void Save(Log log)
        {
            using (SmallCodeContext db = new SmallCodeContext())
            {
                db.Logs.Add(log);
                bool result = db.SaveChanges() > 0;
                base.IsSuccess = result;
                base.ReturnMsg = result ? "保存成功" : "保存失败";
            }
        }
    }
}