using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCodeBoot.Extendsions
{
    public static class EnumExtension
    {
        /// <summary>
        /// 枚举转Int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInteger(this Enum obj)
        {
            return Convert.ToInt32(obj);
        }
    }
}
