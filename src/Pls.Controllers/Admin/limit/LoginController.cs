//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Controllers.Admin/LoginController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc;
using Pls.IService;
using System.Threading.Tasks;
using Pls.Utils;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 登陆业务逻辑实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Login")]
    public class LoginController : BaseController
    {
        public IUserService userService { get; private set; }
        public LoginController(ApplicationConfigServices _applicationConfigServices, IUserService _userService)
            : base(_applicationConfigServices)
        {
            userService = _userService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 系统后端错误页面
        /// </summary>
        /// <returns></returns>
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 根据用户名密码登录后台系统
        /// </summary>
        /// <param name="login_name_in">用户名</param>
        /// <param name="user_pwd_in">密码</param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AjaxOnly]
        public async Task<IActionResult> Login(string login_name_in, string user_pwd_in)
        {
            var data = await userService.Login(login_name_in, user_pwd_in);
            return Json(data);
        }

        /// <summary>
        /// 根据用户Id和输入的内容判断是否存在数据
        /// </summary>
        /// <param name="content">输入的内容</param>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpGet("checkData")]
        public async Task<IActionResult> checkData(string content, string user_id = "0")
        {
            var data = await userService.checkData(user_id, content);
            return Json(data);
        }

        /// <summary>
        /// 根据用户Id和输入的内容判断是否存在数据
        /// </summary>
        /// <param name="user_email">输入的邮箱</param>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpPost("checkEmail")]
        public async Task<IActionResult> checkEmail(string user_email, string user_id = "0")
        {
            var data = await userService.checkData(user_id, user_email);
            return Json(new { valid = !data.data });
        }

        /// <summary>
        /// 根据用户Id和输入的内容判断是否存在数据
        /// </summary>
        /// <param name="user_phone">输入的手机号</param>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpPost("checkMobie")]
        public async Task<IActionResult> checkMobie(string user_phone, string user_id = "0")
        {
            var data = await userService.checkData(user_id, user_phone);
            return Json(new { valid = !data.data });
        }

    }
}