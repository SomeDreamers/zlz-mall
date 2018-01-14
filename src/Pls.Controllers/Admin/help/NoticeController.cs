//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   MartyZane-PC
//  命名空间名称/文件名:        Pls.Controllers.Admin/NoticeController 
//  创建人:			   	  		MartyZane     
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
    /// 公告功能实现页面
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Notice")]
    [Login]
    [AjaxOnly]
    public class NoticeController : BaseController
    {
        //公告类信息注入
        public INoticeService noticeService { get; private set; }
        public NoticeController(ApplicationConfigServices _applicationConfigServices, INoticeService _noticeService)
            : base(_applicationConfigServices)
        {
            noticeService = _noticeService;
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
        /// 根据查询条件查询公告信息--同步方法调用
        /// </summary>
        /// <param name="noticeInfo">查询条件</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(NoticeInfo noticeInfo)
        {
            var data = await noticeService.List(noticeInfo);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 查询所有未禁用的公告信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("listNoDisable")]
        public async Task<IActionResult> listNoDisable()
        {
            var data = await noticeService.listNoDisable();
            return Json(data);
        }

        /// <summary>
        /// 根据主键Id查询公告信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await noticeService.GetById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 部门添加
        /// </summary>
        /// <param name="departmetnEntity">部门条件</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(NoticeEntity noticeEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await noticeService.Add(noticeEntity);
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
        public async Task<IActionResult> Update(NoticeEntity noticeEntity)
        {
            if (ModelState.IsValid)
            {
                var data = await noticeService.Update(noticeEntity);
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
            var data = await noticeService.Disable(department_id, disable_desc, type);
            return Json(data);
        }
    }
}