using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace AutoUpdate.Core.Data
{
    [DataContract]
    public class ConfigInfo
    {
        /// <summary>
        /// 版本更新时间
        /// </summary>
        [DataMember]
        [XmlElement("UpdateDate")]
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 上一版本编号
        /// </summary>
        [DataMember]
        [XmlElement("PreviousVersion")]
        public string PreviousVersion { get; set; }
        /// <summary>
        /// 当前版本编号
        /// </summary>
        [DataMember]
        [XmlElement("CurrentVersion")]
        public string CurrentVersion { get; set; }
        /// <summary>
        /// 当前版本描述说明
        /// </summary>
        [DataMember]
        [XmlElement("Description")]
        public string Description { get; set; }
        /// <summary>
        /// 强制更新
        /// </summary>
        [DataMember]
        [XmlElement("ForceUpdate")]
        public bool ForceUpdate { get; set; }
        /// <summary>
        /// 服务器上做版本备份
        /// </summary>
        [DataMember]
        [XmlElement("ServerBak")]
        public bool ServerBak { get; set; }
        /// <summary>
        /// 版本回滚
        /// </summary>
        [DataMember]
        [XmlElement("RollBack")]
        public bool RollBack { get; set; }
    }
}
