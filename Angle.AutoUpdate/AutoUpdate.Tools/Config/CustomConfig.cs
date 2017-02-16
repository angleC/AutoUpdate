/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/15 9:08:11 
 * 文件名(File Name)：CustomConfig 
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

namespace AutoUpdate.Tools.Config
{
    public class CustomConfig<T> : ConfigurationSection where T : CustomKeyValue
    {
        private static readonly ConfigurationProperty property = new ConfigurationProperty(string.Empty, typeof(CustomKeyValueCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public CustomKeyValueCollection KeyValues
        {
            get { return (CustomKeyValueCollection)base[property]; }
        }

        public static CustomConfig<T> GetConfig(string sectionName)
        {
            CustomConfig<T> configSection = (CustomConfig<T>)ConfigurationManager.GetSection(sectionName);

            if (configSection == null)
                throw new ConfigurationErrorsException(string.Format(@"Section {0} is not found.", sectionName));

            return configSection;
        }

        public static CustomConfig<T> GetConfig(string configPath, string sectionName)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            CustomConfig<T> configSection = (CustomConfig<T>)config.GetSection(sectionName);

            if (configSection == null)
                throw new ConfigurationErrorsException(string.Format(@"Section {0} is not found.", sectionName));

            return configSection;
        }

        [ConfigurationCollection(typeof(CustomKeyValue))]
        public sealed class CustomKeyValueCollection : ConfigurationElementCollection
        {
            new T this[string name]
            {
                get
                {
                    return (T)base.BaseGet(name);
                }
            }

            protected override ConfigurationElement CreateNewElement()
            {
                return default(T);
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((T)element).Name;
            }
        }
    }
    /// <summary>
    /// 自定义配置文件中键值
    /// </summary>
    public class CustomKeyValue : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }
    }
}
