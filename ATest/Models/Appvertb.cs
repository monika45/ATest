//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具 FreeSql.Generator 生成。
//     运行时版本:3.1.2
//     Website: https://github.com/2881099/FreeSql
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;
namespace ATest.Models {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "appvertb")]
	public partial class Appvertb {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		/// <summary>
		/// 渠道
		/// </summary>
		[JsonProperty]
		public int Channel { get; set; }

		[JsonProperty]
		public Guid Gameid { get; set; }

		/// <summary>
		/// 链接类型
		/// </summary>
		[JsonProperty]
		public int Linktype { get; set; }

		/// <summary>
		/// 链接地址
		/// </summary>
		[JsonProperty]
		public string Linkurl { get; set; } = string.Empty;

		/// <summary>
		/// 新版本消息
		///  比如配置弹出对话框的信息
		/// </summary>
		[JsonProperty]
		public string Msg { get; set; } = string.Empty;

		[JsonProperty]
		public int Status { get; set; }

		/// <summary>
		/// 当前最新版本
		/// </summary>
		[JsonProperty]
		public string Version { get; set; } = string.Empty;

	}

}
