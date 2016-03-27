using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCodeBoot.Extendsions
{
    public class LogHelper
    {
        public static void SaveLog(Exception msg)
        {
            try
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "MessageLog.txt";

                System.IO.File.AppendAllText(fileName, msg.Message + "\r\n" + msg.StackTrace, Encoding.UTF8);
            }
            catch (Exception)
            {
            }
        }

        public static void SaveLog(string msg)
        {
            try
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "MessageLog.txt";

                System.IO.File.AppendAllText(fileName, msg + "\r\n", Encoding.UTF8);
            }
            catch (Exception)
            {
            }
        }

        public static void SaveLog(string[] msg)
        {
            try
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "MessageLog.txt";
                foreach (string s in msg)
                {
                    System.IO.File.AppendAllText(fileName, "all:" + s, Encoding.UTF8);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
