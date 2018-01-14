//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/SystemController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/12 11:44:35
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers
{
    /// <summary>
    /// 系统设置管理控制器
    /// </summary>
    public class SystemController : BaseController
    {
        protected INoticeService noticeService;
        protected IUserService userService;
        protected IMessageService messageService;
        public SystemController(ApplicationConfigServices _applicationConfigServices, INoticeService _noticeService, IUserService _userService,
            IMessageService _messageService)
            : base(_applicationConfigServices)
        {
            noticeService = _noticeService;
            userService = _userService;
            messageService = _messageService;
        }

        /// <summary>
        /// 系统反馈的主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await messageService.List(new MessageInfo()
            {
                disable_status = 0,
                offset = 1,
                pagesize = 20
            });
            return View(data.rows);
        }

        /// <summary>
        /// 添加留言实现
        /// </summary>
        /// <param name="message_desc"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddMessage(string message_desc)
        {
            var data = await messageService.Add(return_front_userid(), message_desc);
            return Json(data);
        }

        /// <summary>
        /// 公告实现(返回页面的时候查询所有公告信息)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> News()
        {
            var data = await noticeService.List(new NoticeInfo() { disable = 0, offset = 1, pagesize = 20 });
            return View(data.rows);
        }

        /// <summary>
        /// 关于我们团队(查询后台管理员信息)
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Aboutus()
        {
            var data = await userService.GetTeamUserInfo();
            return View(data);
        }
    }
}