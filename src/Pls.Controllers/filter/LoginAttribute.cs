//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Controllers/LoginAttribute 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Pls.Entity;
using Pls.Utils;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Pls.Controllers
{
    /// <summary>
    /// 拦截器，后端判断用户登录信息(如果用户没有登录或者没有权限访问某些菜单，则提示错误)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LoginAttribute : ActionFilterAttribute
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

            //首先判断用户是否登陆读取到Session，如果没有读取则直接返回登陆页面
            string user_json = context.HttpContext.Session.GetString(KeyUtil.user_info);
            if (!string.IsNullOrEmpty(user_json))
            {
                UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(user_json);

                //根据用户Id和请求路劲查询此页面是否可以访问，如果不能访问，则跳转到登录页面
                ControllerActionDescriptor action = (ControllerActionDescriptor)context.ActionDescriptor;
                string actionurl = string.Format("/{0}/{1}/{2}", action.RouteValues["area"], action.RouteValues["controller"], action.RouteValues["action"]).ToLower();

                //判断是否含有访问这个字段的权限，如果有，则继续，否则跳转到登录页
                if (userSession.action_url == null || !userSession.action_url.Contains(actionurl))
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