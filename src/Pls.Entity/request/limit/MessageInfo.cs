//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.Entity/MessageInfo 
//  创建人:                     Brian     
//  创建时间:                   9/24/2016 9:36:14 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{

    /// <summary>
    /// 留言查询实体
    /// </summary>
    public class MessageInfo : PageEntity
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 启用禁用状态
        /// </summary>
        public int disable_status { get; set; }

    }
}