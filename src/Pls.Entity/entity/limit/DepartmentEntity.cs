//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/DepartmentEntity 
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
    /// 部门表实体
    /// </summary>
    public class DepartmentEntity
    {
        /// <summary>
        /// 部门Id,主键
        /// </summary>
        public string department_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 部门名称
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// 可空  部门描述
        /// </summary>
        public string department_desc { get; set; }

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        ///  可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}