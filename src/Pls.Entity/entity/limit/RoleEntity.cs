//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/RoleEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    ///角色表实体
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// 角色Id,主键
        /// </summary>
        public string role_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_name { get; set; }

        /// <summary>
        /// 可空  角色描述
        /// </summary>
        public string role_desc { get; set; }

        /// <summary>
        /// 前后端区分表示(1:前段，2:后端)，默认2
        /// </summary>
        public int role_type { get; set; } = (int)SourceStatus.admin;

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        ///  可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}