//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	   4.0.30319.42000
//  机器名称:                   DESKTOP-L40HQM6
//  命名空间名称/文件名:        Pls.Controllers.Admin/RoleController 
//  创建人:			   	  		Brian     
//  创建时间:     		  		2016/9/21 23:50:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using System.Threading.Tasks;
using Pls.Utils;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 角色业务逻辑控制器实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Role")]
    [Login]
    [AjaxOnly]
    public class RoleController : BaseController
    {
        //角色信息注入
        public IRoleService roleService { get; private set; }
        public RoleController(ApplicationConfigServices _applicationConfigServices, IRoleService _roleService)
            : base(_applicationConfigServices)
        {
            roleService = _roleService;
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
        /// 根据查询条件查询角色信息--同步方法调用
        /// </summary>
        /// <param name="roleInfo">查询条件</param>
        /// <returns></returns>
        [HttpGet("List")]
        public IActionResult List(RoleInfo roleInfo)
        {
            var data = roleService.List(roleInfo);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 查询所有未禁用的角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("listNoDisable")]
        public async Task<IActionResult> listNoDisable()
        {
            var data = await roleService.listNoDisable();
            return Json(data);
        }

        /// <summary>
        /// 根据主键Id查询角色信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await roleService.GetById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 根据主键Id查询角色信息
        /// </summary>
        /// <param name="roleName">查询条件</param>
        /// <returns></returns>
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string roleId, string roleName)
        {
            var data = await roleService.GetByName(roleId, roleName);
            return Json(data);
        }

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="roleEntity">角色条件</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(RoleEntity roleEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await roleService.Add(roleEntity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="roleEntity">角色条件</param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(RoleEntity roleEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await roleService.Update(roleEntity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="id">角色主键</param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await roleService.Delete(id);
            return Json(data);
        }

        /// <summary>
        /// 角色禁用
        /// </summary>
        /// <param name="role_id">Id</param>
        /// <param name="disable_desc">部门描述</param>
        /// <param name="type">启用禁用类型</param>
        /// <returns></returns>
        [HttpPost("Disable")]
        public async Task<IActionResult> Disable(string role_id, string disable_desc, int type)
        {
            var data = await roleService.Disable(role_id, disable_desc, type);
            return Json(data);
        }
    }
}