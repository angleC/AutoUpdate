/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/10 14:59:18 
 * 文件名(File Name)：ConfigurationManagerHelper 
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
using System.Configuration;
using System.Linq;
using System.Text;

namespace AutoUpdate.Tools
{
    public sealed class ConfigurationManagerHelper
    {
        private Configuration configuration = null;

        private static readonly object synObject = new object();
        private static ConfigurationManagerHelper instance = null;
        public static ConfigurationManagerHelper ConfigurationManagerHelperSingleton
        {
            get
            {
                lock (synObject)
                {
                    return instance ?? (instance = new ConfigurationManagerHelper());
                }
            }
        }

        private ConfigurationManagerHelper()
        {
            this.configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string Get(string key)
        {
            if (this.configuration.AppSettings.Settings[key] == null)
                throw new ArgumentException("在配置文件中无法找到对应的键值");

            return this.configuration.AppSettings.Settings[key].Value;
        }
    }
}
