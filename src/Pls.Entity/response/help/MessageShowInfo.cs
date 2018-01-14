//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/MessageInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/13 16:11:12
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    /// <summary>
    /// 留言模板返回前段响应
    /// </summary>
    public class MessageShowInfo : MessageEntity
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string user_image { get; set; }
    }
}