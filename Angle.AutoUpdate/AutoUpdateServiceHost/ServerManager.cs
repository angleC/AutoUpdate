/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/10 14:34:07 
 * 文件名(File Name)：ServerManager 
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
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using AutoUpdate.ICore.IService;
using AutoUpdate.Tools;
using AutoUpdate.Tools.Log;

namespace AutoUpdateServiceHost
{
    public class ServerManager
    {
        private List<ServiceHost> serviceHosts = new List<ServiceHost>();
        private ServiceConfig serviceConfig = null;
        private string serviceAddress = string.Empty;

        private static readonly object synObject = new object();
        private static ServerManager instance = null;
        public static ServerManager ServerManagerInstance
        {
            get
            {
                lock (synObject)
                {
                    return instance ?? (instance = new ServerManager());
                }
            }
        }

        private ServerManager()
        {
            serviceAddress = ConfigurationManagerHelper.ConfigurationManagerHelperSingleton.Get("serviceAddress");

            if (this.serviceHosts == null)
            {
                this.serviceHosts = new List<ServiceHost>();
            }

            if (this.serviceConfig == null)
            {
                this.serviceConfig = ServiceConfig.GetConfig("services");
            }
        }

        public void StartService()
        {
            string endPointAddress = string.Empty;

            foreach (ServiceConfig.ServiceKeyValue item in serviceConfig.KeyValues)
            {
                if (!this.serviceAddress.EndsWith("/"))
                    endPointAddress = string.Format(@"{0}/{1}", this.serviceAddress, item.URI);
                else
                    endPointAddress = string.Format(@"{0}{1}", this.serviceAddress, item.URI);

                ServiceHost serviceHost = new ServiceHost(Type.GetType(item.Service));

                BasicHttpBinding binding = new BasicHttpBinding();

                binding.MaxBufferSize = 2147483647;
                binding.MaxBufferPoolSize = 2147483647;
                binding.MaxReceivedMessageSize = 2147483647;
                binding.ReaderQuotas.MaxDepth = 2147483647;
                binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                binding.ReaderQuotas.MaxArrayLength = 2147483647;
                binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                binding.TransferMode = TransferMode.Streamed;
                binding.MessageEncoding = WSMessageEncoding.Mtom;
                binding.CloseTimeout = new TimeSpan(0, 10, 0);
                binding.OpenTimeout = new TimeSpan(0, 10, 0);
                binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                binding.SendTimeout = new TimeSpan(0, 10, 0);

                serviceHost.AddServiceEndpoint(Type.GetType(item.Contract), binding, endPointAddress);

                if (serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri(endPointAddress);
                    serviceHost.Description.Behaviors.Add(behavior);
                }

                serviceHost.Opened += delegate
                {
                    Log4NetHelper.WriteLog(string.Format(@"启动对{0}地址监听", endPointAddress));
                };
                serviceHost.Closed += delegate
                {
                    Log4NetHelper.WriteLog(string.Format(@"关闭对{0}地址监听", endPointAddress));
                };
                serviceHost.Open();

                this.serviceHosts.Add(serviceHost);
            }
        }

        public void CloseService()
        {
            if (this.serviceHosts != null && this.serviceHosts.Count > 0)
            {
                foreach (ServiceHost host in this.serviceHosts)
                {
                    if (host != null && host.State != CommunicationState.Closed)
                        host.Close();
                }
            }
        }
    }
}
