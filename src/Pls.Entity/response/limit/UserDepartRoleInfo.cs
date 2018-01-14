//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/UserDepartRoleInfo 
//  创建人:                     kencery     
//  创建时间:                   2016/10/2 20:56:14
//  网站:                       http://www.chuxinm.com
//==============================================================
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 用户-部门-角色关联表查询返回
    /// </summary>
    public class UserDepartRoleInfo
    {
        /// <summary>
        /// 用户Id,主键
        /// </summary>
        [Key]
        public string user_id { get; set; }

        /// <summary>
        /// 可空  用户名(用户设置的真实名称)
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 可空  真实名称(用户设置的真实名称)
        /// </summary>
       public string full_name { get; set; }

        /// <summary>
        /// 用户编号(自动生成四位数)
        /// </summary>
        public string user_code { get; set; }

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
        public int user_gender { get; set; }

        /// <summary>
        /// 可空  注册用户IP
        /// </summary>
        public string user_ip { get; set; }

        /// <summary>
        /// 管理员的来源(前段：1，后端：2),默认1
        /// </summary>
        public int source_type { get; set; }

        /// <summary>
        /// 可空  用户头像
        /// </summary>
        public string user_image { get; set; }

        /// <summary>
        /// 用户激活，未激活的用户不可登陆前后端
        /// </summary>
        public int user_activation { get; set; }

        /// <summary>
        /// 用户访问，不可访问用户不可访问后端，可访问前端
        /// </summary>
        public int user_visit { get; set; }

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime last_time { get; set; }

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; }

        /// <summary>
        ///  可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_name { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public string department_id { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string role_id { get; set; }
    }
}