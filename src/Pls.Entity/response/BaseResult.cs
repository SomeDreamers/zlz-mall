//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/BaseResult 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;

namespace Pls.Entity
{
    /// <summary>
    /// 封装返回的实体集合，前台ajax请求返回固定格式
    /// </summary>
    public class BaseResult<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status_code { get; set; }

        /// <summary>
        /// 状态信息
        /// </summary>
        public string status_message { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        public BaseResult()
        {
            this.timestamp = CommonUtil.TimeSpan();
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="data"></param>
        public BaseResult(T data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = data == null ? 202 : 200;
            this.status_message = SystemUtil.getMessage(status_code);
            this.data = data;
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="status_code"></param>
        public BaseResult(int status_code)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.data = default(T);
            this.status_message = SystemUtil.getMessage(status_code);
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="status_code"></param>
        /// <param name="data"></param>
        public BaseResult(int status_code, T data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.data = data;
            this.status_message = SystemUtil.getMessage(status_code);
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="status_code"></param>
        /// <param name="data"></param>
        public BaseResult(int status_code, string status_message, T data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.data = data;
            this.status_message = status_message;
        }
    }
}