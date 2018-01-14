//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/RoleButtonActionEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 角色按钮页面表实体
    /// </summary>
    public class RoleButtonActionEntity
    {
        /// <summary>
        /// 角色按钮页面Id-主键
        /// </summary>
        public string rolebutton_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 角色Id
        /// </summary>
        public string role_id { get; set; }

        /// <summary>
        /// 页面或者按钮表Id
        /// </summary>
        public string action_id { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}