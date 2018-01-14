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
    /// 部门管理业务接口
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// 异步查询部门列表
        /// </summary>
        /// <param name="departmentInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<DepartmentEntity>>> List(DepartmentInfo departmentInfo);

        /// <summary>
        /// 查询所有未禁用的部门信息
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<IQueryable<DropDownList>>> listNoDisable();

        /// <summary>
        /// 根据主键Id查询部门信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<DepartmentEntity>> GetById(string id);

        /// <summary>
        /// 部门添加
        /// </summary>
        /// <param name="departmetnEntity">部门条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(DepartmentEntity departmentEntity);

        /// <summary>
        /// 部门修改
        /// </summary>
        /// <param name="departmentEntity">部门条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Update(DepartmentEntity departmentEntity);

        /// <summary>
        /// 部门禁用
        /// </summary>
        /// <param name="department_id">Id</param>
        /// <param name="disable_desc">部门描述</param>
        /// <param name="type">启用禁用类型</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string department_id, string disable_desc, int type);
    }
}