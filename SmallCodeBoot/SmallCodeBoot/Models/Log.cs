using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.Models
{
    public class Log
    {
        public int ID { set; get; }

        public LogType Level { set; get; }

        public DateTime CreateDate { set; get; }

        public string Description { get; set; }

        public string Exception { set; get; }

        public string Ip { get; set; }
    }

    public enum LogType { 异常, 记录 }
}