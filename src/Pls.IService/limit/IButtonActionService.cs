//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.IService/IButtonActionService 
//  创建人:                     kencery     
//  创建时间:                   2016/10/6 11:16:00
//  网站:                       http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    /// 页面或者按钮表管理业务接口
    /// </summary>
    public interface IButtonActionService
    {
        /// <summary>
        /// 查询所有未禁用的页面或者按钮的集合（所有用户权限得配置）
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<IQueryable<ZtreeInfo>>> GetZtree();

        /// <summary>
        /// 根据用户Id查询所有未禁用的页面或者按钮的集合(用户临时权限的配置)
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<string>>> GetZtreeById(string user_id);

        /// <summary>
        /// 用户列表—>添加用户临时权限
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="action_id">权限Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddUserAction(string user_id, string action_id);

        /// <summary>
        /// 根据查询条件查询权限一级菜单信息(所有的查询条件只是查询一级菜单)
        /// </summary>
        /// <param name="parentId">父Id</param>
        /// <returns></returns>
        Task<Pager<IQueryable<ButtonActionEntity>>> List(string parentId);

        /// <summary>
        /// 根据主键Id查询页面或按钮信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<ButtonActionEntity>> GetActionById(string id);

        /// <summary>
        /// 增加页面或按钮信息
        /// </summary>
        /// <param name="buttonActionEntity">页面或按钮条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(ButtonActionEntity buttonActionEntity);

        /// <summary>
        /// 修改页面或按钮信息
        /// </summary>
        /// <param name="buttonActionEntity">页面或按钮条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Update(ButtonActionEntity buttonActionEntity);

        /// <summary>
        /// 设置为新旧菜单
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="type">新旧菜单标识</param>
        /// <returns></returns>
        Task<BaseResult<bool>> NewWorn(string id, int type);

        /// <summary>
        /// 禁用页面或按钮信息
        /// </summary>
        /// <param name="action_id">页面或按钮信息Id</param>
        /// <param name="disable_desc">页面或按钮禁用描述</param>
        /// <param name="type">禁用类型</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string action_id, string disable_desc, int type);

        /// <summary>
        /// 查询所有未禁用的角色按钮的集合（所有角色权限得配置）
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<bool>> AddRoleAction(string role_id, string action_id);

        /// <summary>
        /// 根据角色Id查询所有未禁用的页面或者按钮的集合(角色临时权限的配置)
        /// </summary>
        /// <param name="role_id">角色Id</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<string>>> GetZtreeByRoleId(string role_id);

    }
}