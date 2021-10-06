using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Utils.Utils
{
    public static class LoggerUtils
    {
        public static void WriteLog(string p_ClassName, string p_MethodName, string p_Message)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(p_ClassName);
            logger.Info(string.Format("{0} {1} => {2}", p_ClassName, p_MethodName, p_Message));
        }

        public static void WriteLog(string p_ClassName, string p_MethodName, string p_Message, Exception p_Exception)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(p_ClassName);
            logger.Error(string.Format("{0} {1} => {2}", p_ClassName, p_MethodName, p_Message), p_Exception);
        }

        public static void WriteLog(string p_ClassName, string p_MethodName, string p_Message, SqlException p_Exception)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(p_ClassName);
            logger.Error(string.Format("{0} {1} => {2}", p_ClassName, p_MethodName, p_Message), p_Exception);
        }
    }
}
