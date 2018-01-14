//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/AuthAttribute 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/5 18:07:36
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pls.Entity;
using Pls.Utils;
using System;

namespace Pls.Controllers
{
    /// <summary>
    /// 前端管理员授权登录信息(添加此标签则会去验证用户传递过来的权限是否正确，如果正确，才让访问页面)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 验证登录等信息
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext == null || context.HttpContext.Session == null)
            {
                throw new Exception("此特性只适合于Web应用程序使用或者您的服务器Session不可用！");
            }

            //首先读取用户登录的Session信息进行判断
            string userJson = context.HttpContext.Session.GetString(KeyUtil.user_info_front);
            if (!string.IsNullOrEmpty(userJson))
            {
                UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(userJson);
                if (string.IsNullOrEmpty(userSession.user_id))
                {
                    context.HttpContext.Session.SetString(KeyUtil.user_info, "");
                    context.Result = new RedirectToActionResult("Index", "Login", null);
                }
                else
                {
                    base.OnActionExecuting(context);
                }
            }
            else
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
    }
}