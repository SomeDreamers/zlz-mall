//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/UserController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/7 18:21:46
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
    /// 个人中心的用户管理信息
    /// </summary> 
    public class UserController : BaseController
    {
        protected IUserService userService { get; private set; }
        protected IUserApplyService userApplyService { get; private set; }
        public UserController(ApplicationConfigServices _applicationConfigServices, IUserService _userService, IUserApplyService _userApplyService)
            : base(_applicationConfigServices)
        {
            userService = _userService;
            userApplyService = _userApplyService;
        }

        /// <summary>
        /// 个人中心—用户管理
        /// </summary>
        /// <returns></returns>

        [Auth]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await userService.GetById(return_front_userid());
            ViewBag.UserApply = await userApplyService.GetByUserId(return_front_userid());
            return View(data.data);
        }

        /// <summary>
        /// 前台用户修改用户信息
        /// </summary>
        /// <param name="userEntity">传递的用户实体</param>
        /// <returns></returns>
        [Auth]
        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> UpdateUserFront(UserEntity userEntity)
        {
            userEntity.user_id = return_front_userid();
            var data = await userService.UpdateUserFront(userEntity);
            return Json(data);
        }

        /// <summary>
        /// 上传用户头像
        /// </summary>
        /// <returns></returns>
        [Auth]
        [HttpPost]
        public IActionResult UploadUserImage()
        {
            IFormFileCollection files = Request.Form.Files;
            var data = userService.UploadUserImage(files);
            return Json(data);
        }

        /// <summary>
        /// 修改用户上传的图片信息
        /// </summary>
        /// <param name="image_url"></param>
        /// <returns></returns>
        [Auth]
        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> UpdateUserImage(string image_url)
        {
            var data = await userService.UpdateUserImage(return_front_userid(), image_url);
            return Json(data);
        }

        /// <summary>
        /// 用户申请入驻
        /// </summary>
        /// <param name="apply_reason">原因</param>
        /// <returns></returns>
        [Auth]
        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> UpdateApplyUser(string apply_reason)
        {
            UserApplyEntity userApplyEntity = new UserApplyEntity()
            {
                user_id = return_front_userid(),
                apply_reason = apply_reason
            };
            var data = await userApplyService.Add(userApplyEntity);
            return Json(data);
        }
    }
}