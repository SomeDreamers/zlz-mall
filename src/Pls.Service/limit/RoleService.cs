//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-L40HQM6
//  命名空间名称/文件名:         Pls.Service/RoleService 
//  创建人:                     Brian     
//  创建时间:                   9/21/2016 10:57:46 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IService;
using Pls.IRepository;
using System.Linq.Expressions;
using System.Collections.Generic;
using Pls.Utils;

namespace Pls.Service
{
    /// <summary>
    /// 角色表操作接口实现逻辑
    /// </summary>
    public class RoleService : IRoleService
    {
        //注入角色管理操作
        private IRoleRepository roleRepository { get; set; }
        private IRoleButtonActionRepository roleButtonActionRepository { get; set; }
        public RoleService(IRoleRepository _roleRepository, IRoleButtonActionRepository _roleButtonActionRepository)
        {
            roleRepository = _roleRepository;
            roleButtonActionRepository = _roleButtonActionRepository;
        }

        public Pager<IQueryable<RoleEntity>> List(RoleInfo roleInfo)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<RoleEntity, bool>> where_search = LinqUtil.True<RoleEntity>();
            if (!string.IsNullOrEmpty(roleInfo.name))
            {
                where_search = where_search.AndAlso(c => c.role_name.Contains(roleInfo.name));
            }
            if (roleInfo.status != -1)
            {
                where_search = where_search.AndAlso(c => c.disable == roleInfo.status);
            }

            //调用仓储方法查询分页并且响应给前台
            int total = 0;
            List<RoleEntity> list = roleRepository.GetPageAllList<RoleEntity, DateTime, RoleEntity>(
                roleInfo.pageindex, roleInfo.pagesize, where_search, c => c.createtime, null, out total, true);

            return new Pager<IQueryable<RoleEntity>>(total, list.AsQueryable());
        }

        public async Task<BaseResult<IQueryable<DropDownList>>> listNoDisable()
        {
            IQueryable<RoleEntity> data = await roleRepository.GetAllAsync(c => c.disable == 0);
            var result = from n in data
                         select new DropDownList
                         {
                             value = n.role_id,
                             name = n.role_name
                         };
            return new BaseResult<IQueryable<DropDownList>>(200, result);
        }

        public async Task<BaseResult<RoleEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<RoleEntity>(808);
            }

            var roleEntity = await roleRepository.GetAsync(c => c.role_id == id);
            if (roleEntity == null)
            {
                return new BaseResult<RoleEntity>(202);
            }
            return new BaseResult<RoleEntity>(200, roleEntity);
        }

        public async Task<BaseResult<bool>> Add(RoleEntity roleEntity)
        {
            int count = 0;
            if (string.IsNullOrEmpty(roleEntity.role_name))
            {
                return new BaseResult<bool>(808, true);
            }

            //判断Id和名称   若Id为空，则直接判断名称  若Id不为空，则需要判断Id和名称
            if (string.IsNullOrEmpty(roleEntity.role_id))
            {
                count = await roleRepository.CountAsync(c => c.role_name == roleEntity.role_name && c.role_type == 1);
            }
            else
            {
                count = await roleRepository.CountAsync(c => c.role_name == roleEntity.role_name && c.role_id != roleEntity.role_id && c.role_type == 1);
            }

            if (count >= 1)
            {
                return new BaseResult<bool>(900, true);
            }
            var isTrue = await roleRepository.AddAsync(roleEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Update(RoleEntity roleEntity)
        {
            int count = 0;
            if (string.IsNullOrEmpty(roleEntity.role_name))
            {
                return new BaseResult<bool>(808, true);
            }

            //判断是否有别的前端类型数据
            if ((roleEntity.role_type == 1))
            {
                count = await roleRepository.CountAsync(c => c.role_id != roleEntity.role_id && c.role_type == 1);
                if (count >= 1)
                {
                    return new BaseResult<bool>(1001, true);
                }
            }
            count = 0;

            //判断是否存在相同的数据
            count = await roleRepository.CountAsync(c => c.role_name == roleEntity.role_name && c.role_id != roleEntity.role_id);
            if (count >= 1)
            {
                return new BaseResult<bool>(900, true);
            }

            var isTrue = await roleRepository.UpdateAsync(roleEntity, true, true, c => c.role_name, c => c.role_desc, c => c.role_type);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string role_id, string role_desc, int type)
        {
            if (string.IsNullOrEmpty(role_id))
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            RoleEntity roleEntity = await roleRepository.GetAsync(c => c.role_id.Equals(role_id));
            if (string.IsNullOrEmpty(roleEntity.disabledesc))
            {
                str = "{'disable':'" + roleEntity.disable + "','disable_desc':'" + role_desc + "'}";
            }
            else
            {
                str = roleEntity.disabledesc + ",{'disable':'" + roleEntity.disable + "','disable_desc':'" + role_desc + "'}";
            }
            RoleEntity department = new RoleEntity()
            {
                role_id = role_id,
                disabledesc = str,
                disable = type,
                role_type = roleEntity.role_type
            };

            // 判断是否已经关联用户：禁用之前，判断是否跟角色关联(角色权限表和用户临时权限中，如果存在，提示不允许禁用即可)
            int roleButtonActionDataCount = await roleButtonActionRepository.CountAsync(c => c.role_id.Equals(role_id));
            if (roleButtonActionDataCount > 0)
            {
                return new BaseResult<bool>(901);
            }

            var isTrue = await roleRepository.UpdateAsync(department, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<bool>(808);
            }

            RoleEntity roleEntity = new RoleEntity()
            {
                role_id = id
            };
            var isTrue = await roleRepository.DeleteAsync(roleEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> GetByName(string roleId, string roleName)
        {
            int count = 0;
            if (string.IsNullOrEmpty(roleName))
            {
                return new BaseResult<bool>(808, true);
            }

            //判断Id和名称   若Id为空，则直接判断名称  若Id不为空，则需要判断Id和名称
            if (string.IsNullOrEmpty(roleId))
            {
                count = await roleRepository.CountAsync(c => c.role_name == roleName);
            }
            else
            {
                count = await roleRepository.CountAsync(c => c.role_name == roleName && c.role_id != roleId);
            }

            if (count >= 1)
            {
                return new BaseResult<bool>(900, true);
            }
            else
            {
                return new BaseResult<bool>(200, false);
            }
        }
    }
}