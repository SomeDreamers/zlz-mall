//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:    	Pls.Service/DepartmentService 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IService;
using Pls.IRepository;
using System;
using System.Linq.Expressions;
using Pls.Utils;

namespace Pls.Service
{
    /// <summary>
    /// 部门管理业务类
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        //注入用户管理操作
        private IDepartmentRepository departmentRepository { get; set; }
        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }

        public async Task<Pager<IQueryable<DepartmentEntity>>> List(DepartmentInfo departmentInfo)
        {
            //判断查询参数
            Expression<Func<DepartmentEntity, bool>> where = LinqUtil.True<DepartmentEntity>();
            if (!string.IsNullOrEmpty(departmentInfo.name))
            {
                where = where.AndAlso(c => c.department_name.Contains(departmentInfo.name));
            }
            if (departmentInfo.status != -1)
            {
                where = where.AndAlso(c => c.disable == departmentInfo.status);
            }

            //调用仓储方法查询分页并且响应给前台
            int total = await departmentRepository.CountAsync(where);

            IQueryable<DepartmentEntity> list = await departmentRepository.GetPageAllAsync<DepartmentEntity, DateTime, DepartmentEntity>(
                departmentInfo.pageindex, departmentInfo.pagesize, where, c => c.createtime, null, false);

            return new Pager<IQueryable<DepartmentEntity>>(total, list.AsQueryable());
        }

        public async Task<BaseResult<IQueryable<DropDownList>>> listNoDisable()
        {
            IQueryable<DepartmentEntity> data = await departmentRepository.GetAllAsync(c => c.disable == 0);
            var result = from n in data
                         select new DropDownList
                         {
                             value = n.department_id,
                             name = n.department_name
                         };
            return new BaseResult<IQueryable<DropDownList>>(200, result);
        }

        public async Task<BaseResult<DepartmentEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<DepartmentEntity>(808);
            }

            var departmentEntity = await departmentRepository.GetAsync(c => c.department_id == id);
            if (departmentEntity == null)
            {
                return new BaseResult<DepartmentEntity>(202);
            }
            return new BaseResult<DepartmentEntity>(200, departmentEntity);
        }

        public async Task<BaseResult<bool>> Add(DepartmentEntity departmentEntity)
        {
            //在添加之前首先判断数据库中是否含有同名的数据，如果含有数据则不允许插入
            int count = await departmentRepository.CountAsync(c => c.department_name == departmentEntity.department_name && c.department_id != "0");
            if (count >= 1)
            {
                return new BaseResult<bool>(900, false);
            }
            var isTrue = await departmentRepository.AddAsync(departmentEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Update(DepartmentEntity departmentEntity)
        {
            //在修改之前首先判断数据库中是否含有同名的数据，如果含有数据则不允许插入
            int count = await departmentRepository.CountAsync(c => c.department_name == departmentEntity.department_name && c.department_id != departmentEntity.department_id);
            if (count >= 1)
            {
                return new BaseResult<bool>(900, false);
            }

            var isTrue = await departmentRepository.UpdateAsync(departmentEntity, true, true, c => c.department_name, c => c.department_desc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string department_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(department_id))
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            DepartmentEntity departmentEntity = await departmentRepository.GetAsync(c => c.department_id.Equals(department_id));
            if (string.IsNullOrEmpty(departmentEntity.disabledesc))
            {
                str = "{'disable':'" + departmentEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = departmentEntity.disabledesc + ",{'disable':'" + departmentEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            DepartmentEntity department = new DepartmentEntity()
            {
                department_id = department_id,
                disabledesc = str,
                disable = type
            };

            var isTrue = await departmentRepository.UpdateAsync(department, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

    }
}