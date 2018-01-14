//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/SessionExtensions 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/29 14:49:30
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;

namespace Pls.Utils
{
    /// <summary>
    /// 封装Session的扩展方法
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// 读取Session对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonNetHelper.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 设置Session对象
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonNetHelper.SerializeObject(value));

        }
    }
}