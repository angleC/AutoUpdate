/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/14 8:42:34 
 * 文件名(File Name)：UpdateFileInfo 
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
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AutoUpdate.Core.Data
{
    [DataContract]
    public class FileInfo
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        [DataMember]
        [XmlAttribute("name")]
        public string Name { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [DataMember]
        [XmlAttribute("size")]
        public long FileSize { get; set; }
        /// <summary>
        /// 文件所在相对路径
        /// </summary>
        [DataMember]
        [XmlAttribute("relativepath")]
        public string RelativePath { get; set; }
    }
}
