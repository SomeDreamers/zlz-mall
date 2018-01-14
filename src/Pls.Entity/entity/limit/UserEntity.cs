//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/UserEntity 
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
    /// 用户表实体
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// 用户Id,主键
        /// </summary>
        public string user_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 可空  用户名(用户设置的名称)
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 用户真实名称
        /// </summary>
        public string full_name { get; set; }

        /// <summary>
        /// 登陆密码(前段加密、后端加密)
        /// </summary>
        public string user_pwd { get; set; }

        /// <summary>
        /// 用户编号(自动生成四位数)
        /// </summary>
        public string user_code { get; set; } = "#2468";

        /// <summary>
        /// 可空  找回密码使用(建议设置)
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 可空  用户手机号(建议设置)
        /// </summary>
        public string user_phone { get; set; }

        /// <summary>
        /// 用户性别(默认保密)(0:保密/1:男/2:女)
        /// </summary>
        public int user_gender { get; set; } = (int)GenderStatus.mystery;

        /// <summary>
        /// 可空  注册用户IP
        /// </summary>
        public string user_ip { get; set; }

        /// <summary>
        /// 管理员的来源(前段：1，后端：2),默认1
        /// </summary>
        public int source_type { get; set; } = (int)SourceStatus.front;

        /// <summary>
        /// 可空  用户头像
        /// </summary>
        public string user_image { get; set; }

        /// <summary>
        /// 用户激活，未激活的用户不可登陆前后端
        /// </summary>
        public int user_activation { get; set; }

        /// <summary>
        /// 默认不可访问(1)	用户访问，不可访问用户不可访问后端，可访问前端
        /// </summary>
        public int user_visit { get; set; }

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime last_time { get; set; } = DateTime.Now;

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