/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/10 17:01:33 
 * 文件名(File Name)：UpdateSystem 
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
using AutoUpdate.ICore.IService;
using AutoUpdate.Core.Data;
using AutoUpdate.Tools;
using System.IO;

namespace AutoUpdate.Core.Service
{
    public class UpdateSystem : IUpdateSystem
    {
        private const string VERSIONRELATIVEPATH = "UpdateFiles";//版本所存放相对路径

        private string serverURL = ConfigurationManagerHelper.ConfigurationManagerHelperSingleton.Get("serviceAddress");//服务基地址
        private string versionPath = ConfigurationManagerHelper.ConfigurationManagerHelperSingleton.Get("versionPath");//版本存放配置路径
        private string updateConfigPath = string.Empty;//版本配置文件所存放路径
        private IOperateFile operateFile = null;

        public UpdateSystem()
        {
            if (string.IsNullOrEmpty(this.serverURL)) throw new Exception("配置文件中serviceAddress节点为空！");
            if (string.IsNullOrEmpty(versionPath))
            {
                versionPath = System.AppDomain.CurrentDomain.BaseDirectory + VERSIONRELATIVEPATH;
            }
            else
            {
                versionPath = this.versionPath + VERSIONRELATIVEPATH;
            }

            this.updateConfigPath = Path.Combine(this.versionPath, "UpdateConfig.xml");
            this.operateFile = new OperateFile();
        }

        public UpdateConfig GetVersionConfig()
        {
            try
            {
                UpdateConfig config = SerializeHelper.LoadXmlSerializeFile<UpdateConfig>(this.updateConfigPath);

                return config;
            }
            catch (Exception ex)
            {
                AutoUpdate.Tools.Log.Log4NetHelper.ErrorLog("AutoUpdate.Core.Service.UpdateSystem.GetVersionConfig", ex);
            }

            return null;
        }

        public string GenerateVersionConfig(UpdateConfig config)
        {
            try
            {
                config.ConfigInfo.UpdateDate = DateTime.Now;

                SerializeHelper.XmlSerializeToFile(config, this.updateConfigPath);

                return Path.Combine(this.versionPath, config.ConfigInfo.CurrentVersion);
            }
            catch (Exception ex)
            {
                AutoUpdate.Tools.Log.Log4NetHelper.ErrorLog("AutoUpdate.Core.Service.UpdateSystem.GenerateVersionConfig", ex);
            }

            return string.Empty;
        }

        public UploadFileResult UploadUpdateSystemFile(UploadFileInfo uploadFileInfo)
        {
            return this.operateFile.UploadFile(uploadFileInfo);
        }

        public DownloadFileResult DownloadUpdateSystemFile(DownloadFileInfo downFileInfo)
        {
            UpdateConfig config = SerializeHelper.LoadXmlSerializeFile<UpdateConfig>(this.updateConfigPath);
            downFileInfo.PhysicalPath = Path.Combine(this.versionPath, config.ConfigInfo.CurrentVersion) + "\\" + downFileInfo.FileName;
            return this.operateFile.DownloadFile(downFileInfo);
        }
    }
}
