//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.IService/IUserApplyService 
//  创建人:                     Brian     
//  创建时间:                   12/6/2016 9:03:08 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    ///  用户申请访问后台管理业务接口
    /// </summary>
    public interface IUserApplyService
    {
        /// <summary>
        /// 异步查询轮播列表
        /// </summary>
        /// <param name="userApplyInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<UserApplyEntity>>> List(UserApplyInfo userApplyInfo);

        /// <summary>
        /// 根据主键Id查询轮播信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<UserApplyEntity>> GetById(string id);

        /// <summary>
        /// 根据用户Id查询用户申请访问后台实现
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<UserApplyEntity> GetByUserId(string user_id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userApplyEntity">条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(UserApplyEntity userApplyEntity);

        /// <summary>
        /// 审核通过/不通过
        /// </summary>
        /// <param name="apply_id">主键Id</param>
        /// <param name="apply_desc">处理理由</param>
        /// <param name="type">(0:同意，1:不同意)</param>
        /// <param name="user_id">用户Id</param>
        /// <param name="full_name">登录人名称</param>
        /// <returns></returns>
        Task<BaseResult<string>> Apply(string apply_id, string disable_desc, int type, string user_id, string full_name);
    }
}