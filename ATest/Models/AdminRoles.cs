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

	[JsonObject(MemberSerialization.OptIn), Table(Name = "admin_roles")]
	public partial class AdminRoles {

		[JsonProperty, Column(Name = "id", IsPrimary = true, IsIdentity = true)]
		public uint Id { get; set; }

		[JsonProperty, Column(Name = "created_at", DbType = "timestamp")]
		public DateTime? CreatedAt { get; set; }

		[JsonProperty, Column(Name = "name", DbType = "varchar(50)")]
		public string Name { get; set; } = string.Empty;

		[JsonProperty, Column(Name = "slug", DbType = "varchar(50)")]
		public string Slug { get; set; } = string.Empty;

		[JsonProperty, Column(Name = "updated_at", DbType = "timestamp")]
		public DateTime? UpdatedAt { get; set; }

	}

}
