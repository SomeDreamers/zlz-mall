//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Utils/JsonNetHelper 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/29 14:46:00
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Newtonsoft.Json;
using System;

namespace Pls.Utils
{
    /// <summary>
    /// Json.NET,JavaScript两种类型对Json串的操作
    /// 使用： var Demo = JsonNet.JsonNetDeserializeToString<Demo />(string inserted);
    /// </summary>
    public static class JsonNetHelper
    {
        /// <summary>
        /// 将实体对象转换为Json对象，生成字符串
        /// </summary>
        /// <param name="item">实体对象</param>
        /// <returns></returns>
        public static string SerializeObject(object item)
        {
            try
            {
                return JsonConvert.SerializeObject(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 将Json串对象解析成固定的对象信息
        /// </summary>
        /// <typeparam name="T">需要得到解析后对象的实体类型</typeparam>
        /// <param name="jsonStr">json串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonStr)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}