//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/UserAdminInfo 
//  创建人:                     kencery     
//  创建时间:                   2016/10/3 18:08:56
//  网站:                       http://www.chuxinm.com
//==============================================================
using System.Collections.Generic;

namespace Pls.Entity
{
    /// <summary>
    /// 对后台用户进行添加修改的实体对象
    /// </summary>
    public class UserAdminInfo : UserEntity
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public List<string> department_id { get; set; }

    }
}