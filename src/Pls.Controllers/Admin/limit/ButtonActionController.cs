//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Controllers.Admin/ButtonActionControllers 
//  创建人:                     kencery     
//  创建时间:                   2016/10/6 11:14:40
//  网站:                       http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using System.Threading.Tasks;
using Pls.Utils;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 页面或者按钮表控制器的实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/ButtonAction")]
    [Login]
    [AjaxOnly]
    public class ButtonActionController : BaseController
    {
        //页面或者按钮类信息注入

        public IButtonActionService buttonActionService { get; private set; }
        public ButtonActionController(ApplicationConfigServices _applicationConfigServices, IButtonActionService _buttonActionService)
            : base(_applicationConfigServices)
        {
            buttonActionService = _buttonActionService;
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
        /// 查询所有未禁用的页面或者按钮的集合（所有用户权限得配置）
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetZtree")]
        public async Task<IActionResult> GetZtree()
        {
            var data = await buttonActionService.GetZtree();
            return Json(data);
        }

        /// <summary>
        /// 根据查询条件查询权限一级菜单信息(所有的查询条件只是查询一级菜单)
        /// </summary>
        /// <param name="parentId">父Id</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(string parentId = "0")
        {
            var data = await buttonActionService.List(parentId);
            return JsonDate(data);
        }

        /// <summary>
        /// 根据Id查询权限按钮页面表信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("GetActionById")]
        public async Task<IActionResult> GetActionById(string id)
        {
            var data = await buttonActionService.GetActionById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 增加页面或按钮信息
        /// </summary>
        /// <param name="buttonActionEntity">页面或按钮条件</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ButtonActionEntity buttonActionEntity)
        {
            var data = await buttonActionService.Add(buttonActionEntity);
            return Json(data);
        }

        /// <summary>
        /// 修改页面或按钮信息
        /// </summary>
        /// <param name="buttonActionEntity">页面或按钮条件</param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ButtonActionEntity buttonActionEntity)
        {
            var data = await buttonActionService.Update(buttonActionEntity);
            return Json(data);
        }

        /// <summary>
        /// 设置为新旧菜单
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="type">新旧菜单标识</param>
        /// <returns></returns>
        [HttpPut("NewWorn")]
        public async Task<IActionResult> NewWorn(string id, int type)
        {
            var data = await buttonActionService.NewWorn(id, type);
            return Json(data);
        }

        /// <summary>
        /// 禁用页面或按钮信息
        /// </summary>
        /// <param name="action_id">页面或按钮信息Id</param>
        /// <param name="disable_desc">页面或按钮禁用描述</param>
        /// <param name="type">禁用类型</param>
        /// <returns></returns>
        [HttpPut("Disable")]
        public async Task<IActionResult> Disable(string action_id, string disable_desc, int type)
        {
            var data = await buttonActionService.Disable(action_id, disable_desc, type);
            return Json(data);
        }

        /// <summary>
        /// 用户列表—>根据用户Id查询所有未禁用的页面或者按钮的集合(用户临时权限的配置)
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        [HttpGet("GetZtreeById")]
        public async Task<IActionResult> GetZtreeById(string user_id)
        {
            var data = await buttonActionService.GetZtreeById(user_id);
            return Json(data);
        }

        /// <summary>
        /// 用户列表—>添加用户临时权限
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="action_id">权限Id</param>
        /// <returns></returns>
        [HttpPost("AddUserAction")]
        public async Task<IActionResult> AddUserAction(string user_id, string action_id)
        {
            var data = await buttonActionService.AddUserAction(user_id, action_id);
            return Json(data);
        }

        /// <summary>
        /// 角色列表—>根据角色Id查询所有未禁用的页面或者按钮的集合(角色临时权限的配置)
        /// </summary>
        /// <param name="role_id">角色Id</param>
        /// <returns></returns>
        [HttpGet("GetZtreeByRoleId")]
        public async Task<IActionResult> GetZtreeByRoleId(string role_id)
        {
            var data = await buttonActionService.GetZtreeByRoleId(role_id);
            return Json(data);
        }

        /// <summary>
        /// 角色列表—>添加用户临时权限
        /// </summary>
        /// <param name="role_id">角色Id</param>
        /// <param name="action_id">权限Id</param>
        /// <returns></returns>
        [HttpPost("AddRoleAction")]
        public async Task<IActionResult> AddRoleAction(string role_id, string action_id)
        {
            var data = await buttonActionService.AddRoleAction(role_id, action_id);
            return Json(data);
        }
    }
}