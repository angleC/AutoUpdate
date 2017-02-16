/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/14 8:42:24 
 * 文件名(File Name)：UpdateInfo 
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
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using AutoUpdate.Core.Data;

namespace AutoUpdate.Core.Data
{
    [DataContract]
    public class UpdateConfig
    {
        /// <summary>
        /// 更新配置信息
        /// </summary>
        [DataMember]
        [XmlElement("ConfigInfo")]
        public ConfigInfo ConfigInfo { get; set; }
        /// <summary>
        /// 更新文件列表
        /// </summary>
        [DataMember]
        [XmlArray("Files"),XmlArrayItem("file")]
        public List<FileInfo> FileInfo { get; set; }
    }
}
