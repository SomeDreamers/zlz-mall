//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/LoginController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/27 12:58:49
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers
{
    /// <summary>
    /// 前台首页登录注册业务
    /// </summary>
    public class LoginController : BaseController
    {
        public IUserService userService { get; private set; }
        public LoginController(ApplicationConfigServices _applicationConfigServices, IUserService _userService)
            : base(_applicationConfigServices)
        {
            userService = _userService;
        }

        /// <summary>
        /// 登录注册首页-所有来这里的页面都要读取到来访的地址，根据地址在登录完成之后进行跳转
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int type)
        {
            var return_url = HttpContext.Request.Headers["Referer"].ToString();
            ViewBag.Type = type;
            ViewBag.HttpUrl = return_url;
            return View();
        }

        /// <summary>
        /// 用户注册完成之后确认页面提示用户已发送邮件并且激活
        /// </summary>
        /// <returns></returns>
        public IActionResult RegisterOK()
        {
            return View();
        }

        /// <summary>
        /// 用户激活：根据用户邮箱传递的内容进行邮件激活
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="key">用户key（用户名称和邮件生成的Key）</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Activation(string user_id, string key)
        {
            var data = await userService.Activation(user_id, key);
            return View(data);
        }

        /// <summary>
        /// 根据用户名密码登录前端购物商城
        /// </summary>
        /// <param name="login_name_in">用户名</param>
        /// <param name="user_pwd_in">密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string login_name_in, string user_pwd_in)
        {
            var data = await userService.LoginFront(login_name_in, user_pwd_in);
            return Json(data);
        }

        /// <summary>
        /// 前端注册用户信息，不能受权限控制/返回注册成功之后的用户Id和邮箱，，根据Id修改用户名，根据邮箱发送邮件激活 
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await userService.Add(userEntity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 根据用户Id修改用户名称,并且发送激活邮件。
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="user_name">用户名称</param>
        /// <param name="user_email">用户Email</param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateUserName(string user_id, string user_name, string user_email)
        {
            var host_url = HttpContext.Request.Headers["Host"].ToString();
            var data = await userService.UpdateUserName(user_id, user_name, user_email, applicationConfigServices.MailConfigurations, host_url);
            return Json(data);
        }

        /// <summary>
        /// 退出用户，清楚缓存
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Layout()
        {
            HttpContext.Session.SetString(KeyUtil.user_info_front, "");
            return RedirectToAction("Index", "Login");
        }
    }
}