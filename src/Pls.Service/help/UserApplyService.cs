//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.Service/UserApplyService 
//  创建人:                     Brian     
//  创建时间:                   12/6/2016 10:08:32 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
using Pls.IService;
using System;
using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IRepository;
using System.Linq.Expressions;
using Pls.Utils;

namespace Pls.Service
{
    /// <summary>
    /// 入驻管理业务类
    /// </summary>
    public class UserApplyService : IUserApplyService
    {
        IUserApplyRepository userApplyRepository { get; set; }
        IUserRepository userRepository { get; set; }
        public UserApplyService(IUserApplyRepository _userApplyRepository, IUserRepository _userRepository)
        {
            userApplyRepository = _userApplyRepository;
            userRepository = _userRepository;
        }

        public async Task<Pager<IQueryable<UserApplyEntity>>> List(UserApplyInfo userApplyInfo)
        {
            //判断查询参数
            Expression<Func<UserApplyEntity, bool>> where_serch = LinqUtil.True<UserApplyEntity>();
            Expression<Func<UserEntity, bool>> userwhere_serach = LinqUtil.True<UserEntity>();

            if (userApplyInfo.istrue != -1)
            {
                where_serch = userApplyInfo.istrue == 0 ? where_serch.AndAlso(c => c.is_true == false) : where_serch.AndAlso(c => c.is_true == true);
            }
            if (!string.IsNullOrEmpty(userApplyInfo.user_email))
            {
                userwhere_serach = userwhere_serach.AndAlso(c => c.user_email.Contains(userApplyInfo.user_email));
            }

            int pageindex = userApplyInfo.pageindex;
            int total = await userApplyRepository.CountAsync(where_serch);
            //调用仓储方法查询分页并且响应给前台

            IQueryable<UserApplyEntity> query = (from c in await userApplyRepository.GetAllAsync(where_serch)
                                                 join o in await userRepository.GetAllAsync(userwhere_serach) on c.user_id equals o.user_id
                                                 join n in await userRepository.GetAllAsync() on c.detail_id equals n.user_id into joinTemp
                                                 from tmp in joinTemp.DefaultIfEmpty()
                                                 select new UserApplyEntity()
                                                 {
                                                     //使用申请人用户Id和处理人用户Id返回用户邮箱信息
                                                     user_id = o.user_email,
                                                     createtime = c.createtime,
                                                     detail_id = tmp == null ? "" : tmp.full_name,
                                                     apply_id = c.apply_id,
                                                     apply_reason = c.apply_reason,
                                                     apply_desc = c.apply_desc,
                                                     row_number = c.row_number,
                                                     is_true = c.is_true
                                                 }).OrderByDescending(c => c.createtime).Skip((--pageindex * userApplyInfo.pagesize)).Take(userApplyInfo.pagesize);
            return new Pager<IQueryable<UserApplyEntity>>(total, query);
        }

        public async Task<BaseResult<UserApplyEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<UserApplyEntity>(808);
            }

            Expression<Func<UserApplyEntity, bool>> where_serch = LinqUtil.True<UserApplyEntity>();
            where_serch = where_serch.AndAlso(c => c.apply_id.Contains(id));

            //调用仓储方法查询分页并且响应给前台
            UserApplyEntity query = (from c in await userApplyRepository.GetAllAsync(where_serch)
                                     join o in await userRepository.GetAllAsync() on c.user_id equals o.user_id
                                     join n in await userRepository.GetAllAsync() on c.detail_id equals n.user_id into joinTemp
                                     from tmp in joinTemp.DefaultIfEmpty()
                                     select new UserApplyEntity()
                                     {
                                         //使用申请人用户Id和处理人用户Id返回用户邮箱信息
                                         user_id = o.user_email,
                                         createtime = c.createtime,
                                         detail_id = tmp == null ? "" : tmp.full_name,
                                         apply_id = c.apply_id,
                                         apply_reason = c.apply_reason,
                                         apply_desc = c.apply_desc,
                                         row_number = c.row_number,
                                         is_true = c.is_true
                                     }).FirstOrDefault();
            return new BaseResult<UserApplyEntity>(200, query);
        }

        public async Task<UserApplyEntity> GetByUserId(string user_id)
        {
            var data = await userApplyRepository.GetAsync(c => c.user_id == user_id);
            return data;
        }

        public async Task<BaseResult<bool>> Add(UserApplyEntity userApplyEntity)
        {
            var isTrue = await userApplyRepository.AddAsync(userApplyEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<string>> Apply(string apply_id, string disable_desc, int type, string user_id, string full_name)
        {
            if (string.IsNullOrEmpty(apply_id) || string.IsNullOrEmpty(user_id))
            {
                return new BaseResult<string>(808);
            }

            //读取申请表信息判断用户是否处理，如果处理则不允许在处理否则处理结果
            var userapply = await userApplyRepository.GetAsync(u => u.apply_id.Equals(apply_id));
            if (userapply == null || !string.IsNullOrEmpty(userapply.detail_id))
            {
                return new BaseResult<string>(1012);
            }

            //如果type=0处理用户表，否则不处理用户表
            if (type == 0)
            {
                await userRepository.UpdateAsync(new UserEntity() { user_id = userapply.user_id, user_visit = 0 }, true, true, c => c.user_visit);
            }
            userapply.detail_id = user_id;
            userapply.is_true = type == 0 ? true : false;
            userapply.apply_desc = disable_desc;
            var isTrue = await userApplyRepository.UpdateAsync(userapply, true, true, c => c.is_true, c => c.apply_desc, c => c.detail_id);

            if (!isTrue)
            {
                return new BaseResult<string>(201);
            }
            return new BaseResult<string>(200, full_name);
        }
    }
}