//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Controllers/BaseController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pls.Entity;
using Pls.Utils;

namespace Pls.Controllers
{
    /// <summary>
    /// 前端基类控制器，封装一些公共的东西，其它控制器直接继承自BaseController即可。
    /// </summary>
    public class BaseController : Controller
    {
        public readonly ApplicationConfigServices applicationConfigServices;

        public BaseController(ApplicationConfigServices _applicationConfigServices)
        {
            applicationConfigServices = _applicationConfigServices;
        }

        /// <summary>
        /// 重写虚方法(读取系统配置文件)
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //读取网站公共内容发送到前端,后台系统标题、版权、js/CSS版本
            var controller = (BaseController)context.Controller;
            controller.ViewBag.AdminTitle = applicationConfigServices.AppConfigurations.AdminTitle;
            controller.ViewBag.Copyright = applicationConfigServices.AppConfigurations.Copyright;
            controller.ViewBag.AdminKeyWords = applicationConfigServices.AppConfigurations.AdminKeyWords;
            controller.ViewBag.AdminDescription = applicationConfigServices.AppConfigurations.AdminDescription;
            controller.ViewBag.AdminAuthor = applicationConfigServices.AppConfigurations.AdminAuthor;

            //读取登录用户的信息
            //获取Session信息并且返回前台
            UserSession userSession = GetUserSessionFront();
            controller.ViewBag.FrontUserName = userSession == null ? "" : userSession.user_name;
            controller.ViewBag.UserImage = userSession == null || string.IsNullOrEmpty(userSession.user_image) ? "/img/default.jpg" : userSession.user_image;
        }

        /// <summary>
        /// 返回用户登录的Session信息
        /// </summary>
        /// <returns></returns>
        public UserSession GetUserSessionFront()
        {
            string userJson = HttpContext.Session.GetString(KeyUtil.user_info_front);
            if (string.IsNullOrEmpty(userJson))
            {
                return null;
            }
            UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(userJson);
            return userSession;
        }

        /// <summary>
        /// 返回登录用户的user_id
        /// </summary>
        /// <returns></returns>
        public string return_front_userid()
        {
            string userJson = HttpContext.Session.GetString(KeyUtil.user_info_front);
            if (string.IsNullOrEmpty(userJson))
            {
                return "";
            }
            UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(userJson);
            return userSession.user_id;
        }

        /// <summary>
        /// 返回用户登录的Session信息
        /// </summary>
        /// <returns></returns>
        public UserSession GetUserSession()
        {
            string userJson = HttpContext.Session.GetString(KeyUtil.user_info_front);
            if (string.IsNullOrEmpty(userJson))
            {
                return null;
            }
            UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(userJson);
            return userSession;
        }

        /// <summary>
        /// 返回登录用户的user_id
        /// </summary>
        /// <returns></returns>
        public string return_userid()
        {
            string userJson = HttpContext.Session.GetString(KeyUtil.user_info_front);
            if (string.IsNullOrEmpty(userJson))
            {
                return "";
            }
            UserSession userSession = JsonNetHelper.DeserializeObject<UserSession>(userJson);
            return userSession.user_id;
        }

        /// <summary>
        /// 重构方法(如果给前台响应日期时间调用此方法方法)
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public ContentResult JsonDateTime(object result)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, timeConverter));
        }

        /// <summary>
        /// 重构方法(如果给前台响应日期调用此方法方法)
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public ContentResult JsonDate(object result)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, timeConverter));
        }

        /// <summary>
        /// 重构方法(如果给前台响应时间调用此方法方法)
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public ContentResult JsonTime(object result)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, timeConverter));
        }

        /// <summary>
        /// 封装条件验证未通过的返回实体
        /// </summary>
        /// <returns></returns>
        public BaseResult<bool> ParrNoPass()
        {
            return new BaseResult<bool>(800, false);
        }
    }
}
