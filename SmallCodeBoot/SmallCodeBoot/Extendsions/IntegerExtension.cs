using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCodeBoot.Extendsions
{
    public static class IntegerExtension
    {
        /// <summary>
        /// int 转enum
        /// </summary>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int input)
        {
            return (T)Enum.ToObject(typeof(T), input);
        }

    }
}
