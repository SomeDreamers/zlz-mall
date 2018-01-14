//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Service/ButtonActionService 
//  创建人:                     kencery     
//  创建时间:                   2016/10/6 11:17:30
//  网站:                       http://www.chuxinm.com
//==============================================================
using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IService;
using Pls.IRepository;
using System.Collections.Generic;
using Pls.UnitOfWork;

namespace Pls.Service
{
    /// <summary>
    /// 页面或者按钮表管理业务实现
    /// </summary>
    public class ButtonActionService : IButtonActionService
    {
        //注入
        private IButtonActionRepository buttonActionRepository { get; set; }
        private IUserButtonActionRepository userButtonAvtionRepository { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        private IRoleButtonActionRepository roleButtonActionRepository { get; set; }
        public ButtonActionService(IButtonActionRepository _buttonActionRepository, IUnitOfWork _unitOfWork,
            IUserButtonActionRepository _userButtonAvtionRepository, IRoleButtonActionRepository _roleButtonActionRepository)
        {
            buttonActionRepository = _buttonActionRepository;
            unitOfWork = _unitOfWork;
            userButtonAvtionRepository = _userButtonAvtionRepository;
            roleButtonActionRepository = _roleButtonActionRepository;
        }

        public async Task<BaseResult<IQueryable<ZtreeInfo>>> GetZtree()
        {
            //查询未禁用的按钮信息
            var data = from n in await buttonActionRepository.GetAllAsync(c => c.disable == 0)
                       select new ZtreeInfo
                       {
                           id = n.action_id,
                           pId = n.action_parentid,
                           name = n.action_name
                       };
            return new BaseResult<IQueryable<ZtreeInfo>>(200, data);
        }

        public async Task<BaseResult<IQueryable<string>>> GetZtreeById(string user_id)
        {
            var data = from n in await userButtonAvtionRepository.GetAllAsync(c => c.user_id.Equals(user_id))
                       select n.action_id;
            return new BaseResult<IQueryable<string>>(data);
        }

        public async Task<BaseResult<bool>> AddUserAction(string user_id, string action_id)
        {
            try
            {
                //删除中间表之后进行循环添加
                var isDeleteUser = await userButtonAvtionRepository.DeleteByUserId(user_id);
                if (!string.IsNullOrEmpty(action_id))
                {
                    List<string> action_ids = new List<string>(action_id.Split(','));

                    if (action_ids.Count > 0)
                    {
                        List<UserButtonActionEntity> userButtonActionEntitys = new List<UserButtonActionEntity>();
                        foreach (string id in action_ids)
                        {
                            UserButtonActionEntity userRoleEntity = new UserButtonActionEntity();
                            userRoleEntity.user_id = user_id;
                            userRoleEntity.action_id = id;
                            userButtonActionEntitys.Add(userRoleEntity);
                        }
                        var isUserDepartmentTrue = await userButtonAvtionRepository.AddListAsync(userButtonActionEntitys, false);
                    }
                    if (unitOfWork.SaveCommit())
                    {
                        return new BaseResult<bool>(200, true);
                    }
                }
                return new BaseResult<bool>(200, false);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Pager<IQueryable<ButtonActionEntity>>> List(string parentId)
        {
            //根据父Id查询权限信息
            IQueryable<ButtonActionEntity> list = await buttonActionRepository.GetAllAsync(c => c.action_parentid == parentId);
            return new Pager<IQueryable<ButtonActionEntity>>(10000, list.OrderBy(c => c.action_sort));
        }

        public async Task<BaseResult<ButtonActionEntity>> GetActionById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<ButtonActionEntity>(808);
            }

            var buttonActionEntity = await buttonActionRepository.GetAsync(b => b.action_id == id);
            if (buttonActionEntity == null)
            {
                return new BaseResult<ButtonActionEntity>(202);
            }
            return new BaseResult<ButtonActionEntity>(200, buttonActionEntity);
        }

        public async Task<BaseResult<bool>> Add(ButtonActionEntity buttonActionEntity)
        {
            buttonActionEntity.action_newaction = buttonActionEntity.action_type == (int)ActionType.adminleft ? true : false;
            var isTrue = await buttonActionRepository.AddAsync(buttonActionEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Update(ButtonActionEntity buttonActionEntity)
        {
            //在修改之前判断是否有同名的数据，如果有，则不允许修改
            var isTrue = await buttonActionRepository.UpdateAsync(buttonActionEntity, true, true, c => c.action_name, c => c.action_url,
                c => c.action_parentid, c => c.action_icon, c => c.action_sort, c => c.action_event, c => c.action_type);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> NewWorn(string id, int type)
        {
            ButtonActionEntity buttonActionEntity = new ButtonActionEntity()
            {
                action_id = id,
                action_newaction = type == 1 ? true : false
            };
            var isTrue = await buttonActionRepository.UpdateAsync(buttonActionEntity, true, true, c => c.action_newaction);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string action_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(action_id))
            {
                return new BaseResult<bool>(800);
            }

            // 禁用之前，判断是否跟角色用户关联(角色权限表和用户临时权限中，如果存在，提示不允许禁用即可)
            int roleButtonActionDataCount = await roleButtonActionRepository.CountAsync(c => c.action_id.Equals(action_id));
            if (roleButtonActionDataCount > 0)
            {
                return new BaseResult<bool>(901);
            }
            int userButtonActionCount = await userButtonAvtionRepository.CountAsync(c => c.action_id.Equals(action_id));
            if (userButtonActionCount > 0)
            {
                return new BaseResult<bool>(901);
            }

            //首先查询数据读取原始的desc
            var str = "";
            ButtonActionEntity buttonActionEntity = await buttonActionRepository.GetAsync(b => b.action_id.Equals(action_id));
            if (string.IsNullOrEmpty(buttonActionEntity.disabledesc))
            {
                str = "{'disable':'" + buttonActionEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = buttonActionEntity.disabledesc + ",{'disable':'" + buttonActionEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            ButtonActionEntity buttonAction = new ButtonActionEntity()
            {
                action_id = action_id,
                disabledesc = str,
                disable = type
            };

            var isTrue = await buttonActionRepository.UpdateAsync(buttonAction, true, true, b => b.disable, b => b.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> AddRoleAction(string role_id, string action_id)
        {
            try
            {
                //删除中间表之后进行循环添加
                var isDeleteUser = await roleButtonActionRepository.DeleteByRoleId(role_id);
                if (!string.IsNullOrEmpty(action_id))
                {
                    List<string> action_ids = new List<string>(action_id.Split(','));

                    if (action_ids.Count > 0)
                    {
                        List<RoleButtonActionEntity> userButtonActionEntitys = new List<RoleButtonActionEntity>();
                        foreach (string id in action_ids)
                        {
                            RoleButtonActionEntity roleButtonEntity = new RoleButtonActionEntity();
                            roleButtonEntity.role_id = role_id;
                            roleButtonEntity.action_id = id;
                            userButtonActionEntitys.Add(roleButtonEntity);
                        }
                        var isUserDepartmentTrue = await roleButtonActionRepository.AddListAsync(userButtonActionEntitys, false);
                    }
                    if (unitOfWork.SaveCommit())
                    {
                        return new BaseResult<bool>(200, true);
                    }
                }
                return new BaseResult<bool>(200, true);
            }
            catch (System.Exception)
            {
                return new BaseResult<bool>(201, false);
            }
        }

        public async Task<BaseResult<IQueryable<string>>> GetZtreeByRoleId(string role_id)
        {
            var data = from n in await roleButtonActionRepository.GetAllAsync(c => c.role_id.Equals(role_id))
                       select n.action_id;
            return new BaseResult<IQueryable<string>>(data);
        }

    }
}