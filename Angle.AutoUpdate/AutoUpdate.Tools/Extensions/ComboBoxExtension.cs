/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/16 14:07:57 
 * 文件名(File Name)：ComboBoxExtension 
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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate.Tools.Extensions
{
    public static class ComboBoxExtension
    {
        /// <summary>
        /// ComboBox控件数据绑定扩展
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="datetable">表</param>
        /// <param name="valueMember">绑定值列名</param>
        /// <param name="displayMember">显示值列名</param>
        public static void DataBind(this ComboBox combo, DataTable datetable, string valueMember, string displayMember)
        {
            combo.DataSource = null;
            combo.DataSource = datetable;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
        }
        /// <summary>
        /// ComboBox控件数据绑定扩展
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="dicList">字典</param>
        public static void DataBind(this ComboBox combo, Dictionary<string, string> dicList)
        {
            combo.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = dicList;
            combo.DataSource = bs;
            combo.ValueMember = "key";
            combo.DisplayMember = "value";
        }
    }
}
