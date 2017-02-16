using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoUpdate.Core.Data;
using AutoUpdate.ICore.IService;
using AutoUpdate.Tools;
using AutoUpdateServiceAccess;

namespace AutoUpdate.Portal
{
    public class UpdateSystem
    {
        /// <summary>
        /// 更新系统
        /// </summary>
        /// <param name="startForm">启动窗体界面</param>
        /// <param name="clientType">客户端类型</param>
        public static void Update(Form startForm, ClientType clientType)
        {
            string updateConfigPath = System.AppDomain.CurrentDomain.BaseDirectory + "UpdateLog.xml";
            UpdateConfig serverConfig = ServiceManager.ServiceManagerInstance.GetRemotingService<IUpdateSystem>("updateSystem").GetVersionConfig();
            ClientUpdateConfig clientConfig = SerializeHelper.LoadXmlSerializeFile<ClientUpdateConfig>(updateConfigPath);

            if (serverConfig != null)
            {
                if (clientConfig == null || clientConfig.ClientUpdateInfo == null || serverConfig.ConfigInfo.CurrentVersion != clientConfig.ClientUpdateInfo.CurrentVersion)
                {
                    StratUpdateExe(serverConfig.ConfigInfo.ForceUpdate, startForm);
                }
                else
                {
                    Application.Run(startForm);
                }
            }
            else
            {
                Application.Run(startForm);
            }
        }

        private static void StratUpdateExe(bool isUpdate, Form startForm)
        {
            if (isUpdate)
            {
                Process.Start(Application.StartupPath + "/Update.exe");
            }
            else
            {
                DialogResult dr = MessageBox.Show("检测到软件版本更新文件,是否进行软件更新 ?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + "/Update.exe");
                }
                else
                {
                    Application.Run(startForm);
                }
            }
        }
    }
}
