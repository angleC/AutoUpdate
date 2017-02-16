/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/13 10:37:07 
 * 文件名(File Name)：ServiceConfig 
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

namespace AutoUpdateServiceHost
{
    public sealed class ServiceConfig : ConfigurationSection
    {
        private static readonly ConfigurationProperty property = new ConfigurationProperty(string.Empty, typeof(ServiceKeyValueCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public ServiceKeyValueCollection KeyValues
        {
            get { return (ServiceKeyValueCollection)base[property]; }
        }

        public static ServiceConfig GetConfig(string sectionName)
        {
            ServiceConfig configSection = (ServiceConfig)ConfigurationManager.GetSection(sectionName);

            if (configSection == null)
                throw new ConfigurationErrorsException(string.Format(@"Section {0} is not found.", sectionName));

            return configSection;
        }

        public static ServiceConfig GetConfig(string configPath, string sectionName)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ServiceConfig configSection = (ServiceConfig)config.GetSection(sectionName);

            if (configSection == null)
                throw new ConfigurationErrorsException(string.Format(@"Section {0} is not found.", sectionName));

            return configSection;
        }

        [ConfigurationCollection(typeof(ServiceKeyValue))]
        public sealed class ServiceKeyValueCollection : ConfigurationElementCollection
        {
            new ServiceKeyValue this[string name]
            {
                get
                {
                    return (ServiceKeyValue)base.BaseGet(name);
                }
            }

            protected override ConfigurationElement CreateNewElement()
            {
                return new ServiceKeyValue();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ServiceKeyValue)element).Name;
            }
        }

        public class ServiceKeyValue : ConfigurationElement
        {
            [ConfigurationProperty("name", IsRequired = true)]
            public string Name
            {
                get { return this["name"].ToString(); }
                set { this["name"] = value; }
            }

            [ConfigurationProperty("service", IsRequired = true)]
            public string Service
            {
                get { return this["service"].ToString(); }
                set { this["service"] = value; }
            }

            [ConfigurationProperty("contract", IsRequired = true)]
            public string Contract
            {
                get { return this["contract"].ToString(); }
                set { this["contract"] = value; }
            }

            [ConfigurationProperty("uri", IsRequired = true)]
            public string URI
            {
                get { return this["uri"].ToString(); }
                set { this["uri"] = value; }
            }
        }
    }
}
