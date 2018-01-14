//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Controllers.Admin/DepartmentController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
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
    /// 部门功能实现页面
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Department")]
    [Login]
    [AjaxOnly]
    public class DepartmentController : BaseController
    {
        //部门类信息注入
        public IDepartmentService departmentService { get; private set; }
        public DepartmentController(ApplicationConfigServices _applicationConfigServices, IDepartmentService _departmentService)
            : base(_applicationConfigServices)
        {
            departmentService = _departmentService;
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
        /// 根据查询条件查询部门信息--同步方法调用
        /// </summary>
        /// <param name="departmentInfo">查询条件</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(DepartmentInfo departmentInfo)
        {
            var data = await departmentService.List(departmentInfo);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 查询所有未禁用的部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("listNoDisable")]
        public async Task<IActionResult> listNoDisable()
        {
            var data = await departmentService.listNoDisable();
            return Json(data);
        }

        /// <summary>
        /// 根据主键Id查询部门信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await departmentService.GetById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 部门添加
        /// </summary>
        /// <param name="departmetnEntity">部门条件</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(DepartmentEntity departmentEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await departmentService.Add(departmentEntity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 部门修改
        /// </summary>
        /// <param name="departmentEntity">部门条件</param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(DepartmentEntity departmentEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await departmentService.Update(departmentEntity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 部门禁用
        /// </summary>
        /// <param name="department_id">Id</param>
        /// <param name="disable_desc">部门描述</param>
        /// <param name="type">启用禁用类型(1:禁用,0:启用)</param>
        /// <returns></returns>
        [HttpPut("Disable")]
        public async Task<IActionResult> Disable(string department_id, string disable_desc, int type)
        {
            var data = await departmentService.Disable(department_id, disable_desc, type);
            return Json(data);
        }
    }
}