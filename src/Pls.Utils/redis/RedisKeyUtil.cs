//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/RedisKeyUtil 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/23 13:48:51
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Utils
{
    /// <summary>
    /// 保存Redis的键
    /// </summary>
    public class RedisKeyUtil
    {
        /// <summary>
        /// 用户登录后台的redisKey
        /// </summary>
        public static string login_admin = "login_admin_{0}";

        /// <summary>
        /// 用户登录后台之后读取到的左侧导航列表
        /// </summary>
        public static string login_admin_menu = "login_admin_menu_{0}";
    }
}