//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Controllers.Admin/HomeController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using System.Threading.Tasks;
using Pls.Utils;
using Microsoft.AspNetCore.Hosting;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 系统管理员(登录/注册/权限配置)
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Home")]
    [Login]
    public class HomeController : BaseController
    {
        //注入
        private IHostingEnvironment hostingEnv;
        public IUserService userService { get; private set; }
        public HomeController(ApplicationConfigServices _applicationConfigServices, IUserService _userService, IHostingEnvironment _hostingEnv)
            : base(_applicationConfigServices)
        {
            userService = _userService;
            hostingEnv = _hostingEnv;
        }

        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.applicationName = hostingEnv.ApplicationName;
            ViewBag.contentRootPath = hostingEnv.ContentRootPath;
            ViewBag.environmentName = hostingEnv.EnvironmentName;
            ViewBag.webRootPath = hostingEnv.WebRootPath;

            ViewBag.ExpendMoney = applicationConfigServices.AppConfigurations.ExpendMoney;

            //获取Session信息并且返回前台
            UserSession userSession = GetUserSession();
            ViewBag.Admin_UserLogin = userSession == null ? "" : userSession.user_name;
            ViewBag.UserImage = userSession == null || string.IsNullOrEmpty(userSession.user_image) ? "/img/default.jpg" : userSession.user_image;
            return View();
        }

        /// <summary>
        /// Icon图标
        /// </summary>
        /// <returns></returns>
        [HttpGet("Icon")]
        [AjaxOnly]
        public IActionResult Icon()
        {
            return View();
        }

        /// <summary>
        /// 首页读取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        [AjaxOnly]
        public async Task<IActionResult> GetUserInfo()
        {
            var data = await userService.GetUserInfo();
            return JsonDateTime(data);
        }

        /// <summary>
        /// 退出用户
        /// </summary>
        /// <returns></returns>
        [HttpGet("Layout")]
        public IActionResult Layout()
        {
            HttpContext.Session.SetString(KeyUtil.user_info, "");
            return Redirect("/Admin/Login/Index");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="passwordOld">原始密码</param>
        /// <param name="passwordNew">新密码</param>
        /// <returns></returns>
        [HttpPost("UpdatePassword")]
        [AjaxOnly]
        public async Task<IActionResult> UpdatePassword(string passwordOld, string passwordNew)
        {
            UserSession userSession = GetUserSession();
            var data = await userService.UpdatePassword(userSession.user_id, passwordOld, passwordNew);
            return Json(data);
        }
    }
}