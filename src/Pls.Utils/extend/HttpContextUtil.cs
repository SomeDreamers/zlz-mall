//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/HttpContextUtil 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/29 13:58:07
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Pls.Utils;
using System.Linq;

namespace Pls.Utils
{
    /// <summary>
    /// HttpContext对象封装
    /// </summary>
    public class HttpContextUtil
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;
        private ConnectionInfo connectionInfo => httpContextAccessor.HttpContext.Connection;
        public HttpContextUtil(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public string getRemoteIp()
        {
            var ip = httpContextAccessor.HttpContext.Request.Headers["X-Original-For"];
            var ips = ip.FirstOrDefault();
            if (string.IsNullOrEmpty(ips))
            {
                ip = connectionInfo.RemoteIpAddress.ToString();
            }
            return ip;
        }

        public T GetObjectAsJson<T>(string key)
        {
            return session.Get<T>(key);
        }

        public void setObjectAsJson<T>(string key, T value)
        {
            session.Set<T>(key, value);
        }
    }
}