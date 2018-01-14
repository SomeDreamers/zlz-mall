//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/UserSession 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/29 17:37:53
//  网站：				  		http://www.chuxinm.com
//==============================================================

using System;
using System.Collections.Generic;

namespace Pls.Entity
{
    /// <summary>
    /// 当用户登录成功之后用Session存放的信息
    /// </summary>
    public class UserSession
    {
        /// <summary>
        /// 用户Id,主键
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 用户真实名称
        /// </summary>
        public string full_name { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string user_code { get; set; }

        /// <summary>
        /// 可空  用户头像
        /// </summary>
        public string user_image { get; set; }

        /// <summary>
        /// 可空，用户拥有的访问权限的URL集合
        /// </summary>
        public List<string> action_url { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
    }
}