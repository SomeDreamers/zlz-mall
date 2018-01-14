//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.Entity/RoleType 
//  创建人:                     Brian     
//  创建时间:                   9/29/2016 9:26:51 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

using System.ComponentModel;

namespace Pls.Entity
{
    /// <summary>
    /// 角色类别枚举
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// 前端
        /// </summary>
        [Description("前端")]
        Front = 1,

        /// <summary>
        /// 后端
        /// </summary>
        [Description("后端")]
        Admin = 2,
    }
}