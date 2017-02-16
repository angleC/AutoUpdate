/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/15 15:20:43 
 * 文件名(File Name)：ClientUpdateInfo 
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
using System.Xml.Serialization;

namespace AutoUpdate.Core.Data
{
    public class ClientUpdateInfo
    {
        /// <summary>
        /// 版本更新时间
        /// </summary>
        [XmlElement("UpdateDate")]
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 上一版本编号
        /// </summary>
        [XmlElement("PreviousVersion")]
        public string PreviousVersion { get; set; }
        /// <summary>
        /// 当前版本编号
        /// </summary>
        [XmlElement("CurrentVersion")]
        public string CurrentVersion { get; set; }
    }
}
