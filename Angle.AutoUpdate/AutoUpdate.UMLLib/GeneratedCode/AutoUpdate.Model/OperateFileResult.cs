﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
namespace AutoUpdate.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class OperateFileResult : FileBaseInfo
	{
		/// <summary>
		/// 操作结果
		/// </summary>
		public  ResultType OperateResult
		{
			get;
			set;
		}

		/// <summary>
		/// 返回信息
		/// </summary>
		public  string ResultMessage
		{
			get;
			set;
		}

	}
}

