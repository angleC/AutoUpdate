/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/1/10 9:34:21 
 * 文件名(File Name)：ServiceAPI 
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
using System.Linq;
using System.Text;
using System.Collections;
using System.ServiceProcess;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Configuration.Install;

namespace AutoUpdateServer
{
    public class ServiceAPI
    {
        /// <summary>
        /// 判断服务是否存在
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns></returns>
        internal static bool IsExist(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns></returns>
        internal static int GetServiceStatus(string serviceName)
        {
            int ret = 0;
            try
            {
                ServiceController sc = new ServiceController(serviceName);

                ret = Convert.ToInt16(sc.Status);
            }
            catch (Exception ex)
            {
                ret = 0;
            }

            return ret;
        }
        /// <summary>
        /// 获取服务版本
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns></returns>
        internal static string GetServiceVersion(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                return string.Empty;
            }
            try
            {
                string path = GetWindowsServiceInstallPath(serviceName) + "\\" + serviceName + ".exe";
                Assembly assembly = Assembly.LoadFile(path);
                AssemblyName assemblyName = assembly.GetName();
                Version version = assemblyName.Version;
                return version.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>  
        /// 安装Windows服务  
        /// </summary>  
        /// <param name="stateSaver">集合</param>  
        /// <param name="serviceFilePath">程序文件路径</param>  
        internal static void InstallService(IDictionary stateSaver, string serviceFilePath)
        {
            AssemblyInstaller assemblyInstaller = new AssemblyInstaller();
            assemblyInstaller.UseNewContext = true;
            assemblyInstaller.Path = serviceFilePath;
            assemblyInstaller.Install(stateSaver);
            assemblyInstaller.Commit(stateSaver);
            assemblyInstaller.Dispose();
        }
        /// <summary>  
        /// 卸载Windows服务  
        /// </summary>  
        /// <param name="serviceFilePath">程序文件路径</param>  
        internal static void UnInstallService(string serviceFilePath)
        {
            AssemblyInstaller assemblyInstaller = new AssemblyInstaller();
            assemblyInstaller.UseNewContext = true;
            assemblyInstaller.Path = serviceFilePath;
            assemblyInstaller.Uninstall(null);
            assemblyInstaller.Dispose();
        }
        /// <summary>  
        /// 启动服务  
        /// </summary>  
        /// <param name=" serviceName ">服务名</param>  
        /// <returns>存在返回 true,否则返回 false;</returns>  
        internal static bool RunService(string serviceName)
        {
            bool bo = true;
            try
            {
                ServiceController sc = new ServiceController(serviceName);
                if (sc.Status.Equals(ServiceControllerStatus.Stopped) || sc.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    sc.Start();
                }
            }
            catch (Exception ex)
            {
                bo = false;
            }

            return bo;
        }
        /// <summary>  
        /// 停止服务  
        /// </summary>  
        /// <param name=" serviceName ">服务名称</param>  
        /// <returns>存在返回 true,否则返回 false;</returns>  
        internal static bool StopService(string serviceName)
        {
            bool bo = true;
            try
            {
                ServiceController sc = new ServiceController(serviceName);
                if (!sc.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    sc.Stop();
                }
            }
            catch (Exception ex)
            {
                bo = false;
            }

            return bo;
        }
        /// <summary>
        /// 获取服务安装路径
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns></returns>
        private static string GetWindowsServiceInstallPath(string serviceName)
        {
            string path = "";
            try
            {
                string key = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
                path = Registry.LocalMachine.OpenSubKey(key).GetValue("ImagePath").ToString();

                path = path.Replace("\"", string.Empty);//替换掉双引号

                FileInfo fi = new FileInfo(path);
                path = fi.Directory.ToString();
            }
            catch (Exception ex)
            {
                path = "";
            }
            return path;
        }
    }
}
