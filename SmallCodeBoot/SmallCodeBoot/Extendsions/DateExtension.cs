using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCodeBoot.Extendsions
{
    public static class DateExtension
    {
        /// <summary>
        /// 时间转星期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToWeek(this DateTime date)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(date.DayOfWeek.ToString("d"))].ToString();
            return week;
        }

        /// <summary>
        /// 判断是不是今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date)
        {
            return date.DayOfYear == DateTime.Now.DayOfYear;
        }
    }
}
