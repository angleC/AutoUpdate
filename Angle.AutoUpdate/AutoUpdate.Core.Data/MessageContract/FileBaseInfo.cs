﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
namespace AutoUpdate.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;

    [MessageContract]
    public class FileBaseInfo
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        [MessageHeader]
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        [MessageHeader]
        public long FileSize
        {
            get;
            set;
        }

        /// <summary>
        /// 文件物理路径
        /// </summary>
        [MessageHeader]
        public string PhysicalPath
        {
            get;
            set;
        }

        /// <summary>
        /// 文件相对路径
        /// </summary>
        [MessageHeader]
        public string RelativePath
        {
            get;
            set;
        }
    }
}

