//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-L40HQM6
//  命名空间名称/文件名:         Pls.IService/IRoleService 
//  创建人:                     Brian     
//  创建时间:                   9/21/2016 10:55:07 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    /// 角色管理业务接口
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 异步查询角色列表
        /// </summary>
        /// <param name="roleInfo">查询条件</param>
        /// <returns></returns>
        Pager<IQueryable<RoleEntity>> List(RoleInfo roleInfo);

        /// <summary>
        /// 查询所有未禁用的角色信息
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<IQueryable<DropDownList>>> listNoDisable();

        /// <summary>
        /// 根据主键Id查询角色信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<RoleEntity>> GetById(string id);

        /// <summary>
        /// 根据角色名称查询角色信息
        /// </summary>
        /// <param name="roleName">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> GetByName(string roleId, string roleName);

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="roleEntity">角色条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(RoleEntity roleEntity);

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="roleEntity">角色条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Update(RoleEntity roleEntity);

        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="id">角色主键</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Delete(string id);

        /// <summary>
        /// 角色禁用
        /// </summary>
        /// <param name="role_id">Id</param>
        /// <param name="role_desc">角色描述</param>
        /// <param name="type">启用禁用类型</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string role_id, string role_desc, int type);

    }
}