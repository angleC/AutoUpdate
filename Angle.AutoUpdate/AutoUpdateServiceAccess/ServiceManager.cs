/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/14 14:19:45 
 * 文件名(File Name)：ServiceManager 
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
using AutoUpdate.Tools;
using AutoUpdateServiceAccess.CustomConfig;

namespace AutoUpdateServiceAccess
{
    public class ServiceManager
    {
        private CustomConfig.ServiceConfig serviceConfig = null;

        private static readonly object synObject = new object();
        private static ServiceManager instance = null;
        public static ServiceManager ServiceManagerInstance
        {
            get
            {
                lock (synObject)
                {
                    return instance ?? (instance = new ServiceManager());
                }
            }
        }

        private ServiceManager()
        {
            if (this.serviceConfig == null)
            {
                this.serviceConfig = CustomConfig.ServiceConfig.GetConfig("Services.config","services");
            }
        }

        public T GetRemotingService<T>(string serviceName)
        {
            string url = this.GetServiceUrl(serviceName);
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException(string.Format(@"无法找到名称为{0}的服务", serviceName));

            return InvokeWcfContext.CreateWcfServiceByURL<T>(url);
        }

        private string GetServiceUrl(string serviceName)
        {
            foreach (ServiceConfig.ServiceKeyValue item in this.serviceConfig.KeyValues)
            {
                if (item.Name == serviceName)
                    return item.Url;
            }

            return string.Empty;
        }
    }
}
