/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/13 14:01:02 
 * 文件名(File Name)：Log4NetHelper 
 * 
 * 修改记录(Update Record):
 *  R1.
 *      修改作者(Update Author):           
 *      修改时间(Update Datetime):               
 *      修改说明(Update Description): 
 * ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net.Config;
using System.Reflection;

namespace AutoUpdate.Tools.Log
{
    public static class Log4NetHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        static Log4NetHelper()
        {
            XmlConfigurator.Configure(new FileInfo("Log/log4net.config"));
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="info">日志信息内容</param>
        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        /// <summary>
        /// 错误记录
        /// </summary>
        /// <param name="ex">错误</param>
        public static void ErrorLog(Exception ex)
        {
            ErrorLog(string.Empty, ex);
        }

        /// <summary>
        /// 错误记录
        /// </summary>
        /// <param name="info">附加信息</param>
        /// <param name="ex">错误</param>
        public static void ErrorLog(string info, Exception ex)
        {
            if (!string.IsNullOrEmpty(info) && ex == null)
            {
                logerror.ErrorFormat("【附加信息】 : {0}<br>", new object[] { info });
            }
            else if (!string.IsNullOrEmpty(info) && ex != null)
            {
                string errorMsg = BeautyErrorMsg(ex);
                logerror.ErrorFormat("【附加信息】 : {0}<br>{1}", new object[] { info, errorMsg });
            }
            else if (string.IsNullOrEmpty(info) && ex != null)
            {
                string errorMsg = BeautyErrorMsg(ex);
                logerror.Error(errorMsg);
            }
        }

        /// <summary>
        /// 格式化错误信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误信息</returns>
        private static string BeautyErrorMsg(Exception ex)
        {
            string errorMsg = string.Format("【异常类型】：{0} <br>【异常信息】：{1} <br>【堆栈调用】：{2}", new object[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            errorMsg = errorMsg.Replace("\r\n", "<br>");
            errorMsg = errorMsg.Replace("位置", "<strong style=\"color:red\">位置</strong>");
            return errorMsg;
        }
    }
}
