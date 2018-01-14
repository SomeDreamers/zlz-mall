//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.Entity/UserApplyInfo 
//  创建人:                     Brian     
//  创建时间:                   12/6/2016 9:32:52 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    public class UserApplyInfo : PageEntity
    {
        /// <summary>
        /// 申请者邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// (默认否:false) 是否同意(管理员设置)
        /// </summary>
        public int istrue { get; set; }
    }
}