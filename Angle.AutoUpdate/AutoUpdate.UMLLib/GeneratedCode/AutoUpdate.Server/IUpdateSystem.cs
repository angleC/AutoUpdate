﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
namespace AutoUpdateServer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IUpdateSystem  : IOperateFile
	{
		/// <summary>
		/// 获取版本配置文件
		/// </summary>
		string GetVersionConfig();

		/// <summary>
		/// 更新文件上传之后，生成新版本配置文件
		/// </summary>
		void GenerateVersionConfig();

	}
}

