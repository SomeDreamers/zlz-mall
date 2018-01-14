//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-L40HQM6
//  命名空间名称/文件名:        Pls.Entity/RoleInfo 
//  创建人:                     Brian     
//  创建时间:                   9/21/2016 11:20:13 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 角色查询实体
    /// </summary>
    public class RoleInfo : PageEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 来源状态选择
        /// </summary>
        public int source { get; set; }

        /// <summary>
        /// 角色状态(是否禁用)
        /// </summary>
        public int status { get; set; }
    }
}