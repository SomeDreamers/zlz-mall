//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers.Admin/MessageController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/20 14:23:29
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 留言、建议表控制器的实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Message")]
    [Login]
    [AjaxOnly]
    public class MessageController : BaseController
    {
        /// <summary>
        /// 留言注入
        /// </summary>
        private IMessageService messageService;
        public MessageController(ApplicationConfigServices _applicationConfigServices, IMessageService _messageService)
            : base(_applicationConfigServices)
        {
            messageService = _messageService;
        }

        /// <summary>
        /// 留言、建议表首页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  根据查询条件异步查询版本列表
        /// </summary>
        /// <param name="versionInfo">版本实体</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(MessageInfo messageInfo)
        {
            var data = await messageService.List(messageInfo);
            return JsonDate(data);
        }

        /// <summary>
        /// 根据留言Id查询留言详情信息
        /// </summary>
        /// <param name="version_id">版本Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string message_id)
        {
            var data = await messageService.GetById(message_id);
            return JsonDateTime(data);
        }

        [HttpGet("GetMessageTypeNameByMsgType")]
        public IActionResult GetMessageTypeNameByMsgType(string messageType)
        {
            var data = messageService.GetMessageTypeNameByMsgType(messageType);
            return JsonDate(data);
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("Disable")]
        public async Task<IActionResult> Disable(string[] message_id, string disable_desc, int type)
        {
            var data = await messageService.Disable(message_id, disable_desc, type);
            return Json(data);
        }

        /// <summary>
        /// 留言修改成已读
        /// </summary>
        /// <param name="idList">修改条件</param>
        /// <returns></returns>
        [HttpPost("UpdateRead")]
        public async Task<IActionResult> UpdateRead(string[] idList)
        {
            var data = await messageService.UpdateRead(idList);
            return Json(data);
        }

        /// <summary>
        /// 设置为已读
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpPost("SetResolve")]
        public async Task<IActionResult> SetResolve(string[] idList)
        {
            var data = await messageService.SetResolve(idList);
            return Json(data);
        }

        /// <summary>
        /// 删除留言信息
        /// </summary>
        /// <param name="messge_id">留言Id</param>
        /// <returns></returns>
        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(string[] messge_id)
        {
            var data = await messageService.Delete(messge_id);
            return Json(data);
        }
    }
}