//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/AjaxOnlyAttribute 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/29 14:12:15
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Pls.Controllers
{

    /// <summary>
    /// Ajax请求，限制只能用AJax访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext == null)
            {
                throw new Exception("此特性只适合于Web应用程序使用！");
            }

            //判断只允许用异步去查询
            if (IsAjaxRequest(context.HttpContext))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }

        /// <summary>
        /// 封装异步查询，判断请求是否是异步
        /// </summary>
        /// <param name="request">返回true则表示异步</param>
        /// <returns></returns>
        private static bool IsAjaxRequest(HttpContext request)
        {
            var query = request.Request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            var headers = request.Request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }
    }
}