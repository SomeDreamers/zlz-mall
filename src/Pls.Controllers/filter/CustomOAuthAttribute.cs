using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pls.Entity;
using Pls.Utils;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Controllers.filter
{
    /// <summary>
    /// OAuth自动验证，可以加在Action或整个Controller上
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomOAuthAttribute : ActionFilterAttribute
    {
        protected string _appId { get; set; }
        protected string _oauthCallbackUrl { get; set; }
        protected OAuthScope _oauthScope { get; set; }
        public CustomOAuthAttribute(string appId = null, string oauthCallbackUrl = null, OAuthScope oauthScope = OAuthScope.snsapi_userinfo)
        {
            _appId = appId ?? WeixinConfig.AppId;
            _oauthCallbackUrl = oauthCallbackUrl ?? WeixinConfig.WeixinOAuthCallbackUrl;
            _oauthScope = oauthScope;
        }

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
                base.OnActionExecuting(context);
            }
            else
            {
                var state = string.Format("{0}|{1}", "FromSenparc", DateTime.Now.Ticks);
                context.HttpContext.Session.Set("state", state);//储存随机数到Session
                var callbackUrl = Senparc.Weixin.HttpUtility.UrlUtility.GenerateOAuthCallbackUrl(context.HttpContext, _oauthCallbackUrl);
                var url = OAuthApi.GetAuthorizeUrl(_appId, callbackUrl, state, _oauthScope);
                context.Result = new RedirectResult(url);
            }
        }
        
        
    }
}
