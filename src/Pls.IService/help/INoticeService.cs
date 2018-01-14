//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.IService/IDepartmentService 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    /// 公告管理业务接口
    /// </summary>
    public interface INoticeService
    {
        /// <summary>
        /// 异步查询公告列表
        /// </summary>
        /// <param name="noticeInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<NoticeEntity>>> List(NoticeInfo noticeInfo);

        /// <summary>
        /// 查询所有未禁用的公告信息
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<IQueryable<DropDownList>>> listNoDisable();

        /// <summary>
        /// 根据主键Id查询公告信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<NoticeEntity>> GetById(string id);

        /// <summary>
        /// 公告添加
        /// </summary>
        /// <param name="noticeEntity">公告条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(NoticeEntity noticeEntity);

        /// <summary>
        /// 公告修改
        /// </summary>
        /// <param name="noticeEntity">公告条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Update(NoticeEntity noticeEntity);

        /// <summary>
        /// 公告禁用
        /// </summary>
        /// <param name="notice_id">Id</param>
        /// <param name="disable_desc">公告描述</param>
        /// <param name="type">启用禁用类型</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string notice_id, string disable_desc, int type);
    }
}