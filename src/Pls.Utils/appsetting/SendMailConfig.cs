//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Utils/SendMailConfig 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/10/29 0:04:46
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Utils
{
    /// <summary>
    /// 邮件服务器配置信息
    /// </summary>
    public class SendMailConfig
    {
        /// <summary>
        /// 发送者名称
        /// </summary>
        public string SendServerName { get; set; }

        /// <summary>
        /// 发送者地址
        /// </summary>
        public string SendServerAddress { get; set; }

        /// <summary>
        /// 发送者密码
        /// </summary>
        public string SendServerPwd { get; set; }

        /// <summary>
        /// 邮件发送服务器地址
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        /// 邮件发送服务器端口
        /// </summary>
        public int ServerPort { get; set; }
    }
}