//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/UserInfo 
//  创建人:                     kencery     
//  创建时间:                   2016/10/1 18:29:54
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 用户查询实体
    /// </summary>
    public class UserInfo : PageEntity
    {
        /// <summary>
        /// 用户查询条件
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 性别状态
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// 来源状态选择
        /// </summary>
        public int source { get; set; }

        /// <summary>
        /// 部门状态(是否禁用)
        /// </summary>
        public int status { get; set; }
    }
}