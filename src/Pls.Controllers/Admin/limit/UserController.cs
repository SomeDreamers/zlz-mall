//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers.Admin/UserController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/28 19:32:48
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using System.Threading.Tasks;
using Pls.Utils;
using System.Collections.Generic;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 用户业务逻辑实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/User")]
    [Login]
    [AjaxOnly]
    public class UserController : BaseController
    {
        public IUserService userService { get; private set; }
        public UserController(ApplicationConfigServices _applicationConfigServices, IUserService _userService)
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
        /// 根据查询条件查询人员信息
        /// </summary>
        /// <param name="userInfo">查询条件</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(UserInfo userInfo)
        {
            var data = await userService.List(userInfo);
            return JsonDate(data);
        }

        /// <summary>
        /// 根据主键Id查询人员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await userService.GetById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 根据主键Id查询人员-部门-角色表信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("getInnerById")]
        public async Task<IActionResult> getInnerById(string id)
        {
            var data = await userService.getInnerById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 人员添加（从后台添加，数据来源于后台）
        /// </summary>
        /// <param name="userAdminInfo">人员实体</param>
        /// <returns></returns>
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin(UserAdminInfo userAdminInfo)
        {
            var data = await userService.AddAdmin(userAdminInfo);
            return Json(data);
        }

        /// <summary>
        /// 人员修改(从后台对人员进行修改)(admin用户只能对admin用户进行修改，不可做其它修改)
        /// </summary>
        /// <param name="userAdminInfo">用户实体</param>
        /// <returns></returns>
        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin(UserAdminInfo userAdminInfo)
        {
            var data = await userService.UpdateAdmin(userAdminInfo, GetUserSession().user_id);
            return Json(data);
        }

        /// <summary>
        /// 人员禁用
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="disable_desc">用户禁用详情</param>
        /// <param name="type">启用禁用类型(1:禁用,0:启用)</param>
        /// <returns></returns>
        [HttpPut("Disable")]
        public async Task<IActionResult> Disable(string user_id, string disable_desc, int type)
        {
            var data = await userService.Disable(user_id, disable_desc, type);
            return Json(data);
        }

        /// <summary>
        /// 为用户设置角色
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="role_id">角色集合</param>
        /// <returns></returns>
        [HttpPost("UpdateSetRole")]
        public async Task<IActionResult> UpdateSetRole(string user_id, List<string> role_ids)
        {
            var data = await userService.UpdateSetRole(user_id, role_ids);
            return Json(data);
        }

        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpPut("Activate")]
        public async Task<IActionResult> Activate(string user_id)
        {
            var data = await userService.Activate(user_id);
            return Json(data);
        }

        /// <summary>
        /// 访问开启
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpPut("Visit")]
        public async Task<IActionResult> Visit(string user_id)
        {
            var data = await userService.Visit(user_id);
            return Json(data);
        }

        /// <summary>
        /// 删除用户，物理删除
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string user_id)
        {
            var data = await userService.Delete(user_id);
            return Json(data);
        }
    }
}