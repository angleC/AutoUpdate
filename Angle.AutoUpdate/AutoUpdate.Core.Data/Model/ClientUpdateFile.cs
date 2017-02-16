/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/15 15:18:22 
 * 文件名(File Name)：ClientUpdateFile 
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
    public class ClientUpdateFile : FileInfo
    {
        [XmlAttribute("update")]
        public bool IsUpdate { get; set; }
    }
}
