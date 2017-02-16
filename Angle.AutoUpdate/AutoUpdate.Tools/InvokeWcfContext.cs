/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/13 8:40:23 
 * 文件名(File Name)：InvokeWcfContext 
 * 
 * 修改记录(Update Record):
 *  R1.
 *      修改作者(Update Author):           
 *      修改时间(Update Datetime):               
 *      修改说明(Update Description): 
 * ======================================================================== 
*/
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;

namespace AutoUpdate.Tools
{
    /// <summary>
    /// wcf动态调用上下文
    /// </summary>
    public class InvokeWcfContext
    {
        #region Wcf服务工厂
        /// <summary>
        /// 创建Wcf服务，默认绑定模式为 BasicHttpBinding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T CreateWcfServiceByURL<T>(string url)
        {
            BasicHttpBinding ws = new BasicHttpBinding();
            ws.MaxBufferSize = 2147483647;
            ws.MaxBufferPoolSize = 2147483647;
            ws.MaxReceivedMessageSize = 2147483647;
            ws.ReaderQuotas.MaxDepth = 2147483647;
            ws.ReaderQuotas.MaxStringContentLength = 2147483647;
            ws.ReaderQuotas.MaxArrayLength = 2147483647;
            ws.ReaderQuotas.MaxBytesPerRead = 2147483647;
            ws.ReaderQuotas.MaxNameTableCharCount = 2147483647;
            ws.TransferMode = TransferMode.Streamed;
            ws.MessageEncoding = WSMessageEncoding.Mtom;
            ws.CloseTimeout = new TimeSpan(0, 10, 0);
            ws.OpenTimeout = new TimeSpan(0, 10, 0);
            ws.ReceiveTimeout = new TimeSpan(0, 10, 0);
            ws.SendTimeout = new TimeSpan(0, 10, 0);

            return CreateWcfServiceByURL<T>(url, ws);
        }
        /// <summary>
        /// 创建Wcf服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="binding">默认绑定模式</param>
        /// <returns></returns>
        public static T CreateWcfServiceByURL<T>(string url, Binding binding)
        {
            if (string.IsNullOrEmpty(url)) throw new NotSupportedException("url isn`t Null or Empty!");

            EndpointAddress address = new EndpointAddress(url);
            ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
            foreach (OperationDescription op in factory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>()
                  as DataContractSerializerOperationBehavior;
                if (dataContractBehavior != null)
                {
                    dataContractBehavior.MaxItemsInObjectGraph = 2147483647;
                }
            }

            return factory.CreateChannel();
        }
        #endregion
    }
}
