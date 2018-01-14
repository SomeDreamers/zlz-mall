//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/UserApplyEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/6 13:44:14
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 用户申请访问后台表(Pls_User_Apply)
    /// </summary>
    public class UserApplyEntity
    {
        /// <summary>
        ///  用户申请访问后台表-主键
        /// </summary>
        public string apply_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 创建者用户Id   
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 申请理由
        /// </summary>
        public string apply_reason { get; set; }

        /// <summary>
        /// 是否同意，默认false
        /// </summary>
        public bool is_true { get; set; } = false;

        /// <summary>
        /// 同意/拒绝理由
        /// </summary>
        public string apply_desc { get; set; }

        /// <summary>
        /// 处理人Id
        /// </summary>
        public string detail_id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}