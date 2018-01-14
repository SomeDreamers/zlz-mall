//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   MartyZane-PC
//  命名空间名称/文件名:    	Pls.Service/NoticeService 
//  创建人:			   	  		MartyZane     
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
    /// 公告管理业务类
    /// </summary>
    public class NoticeService : INoticeService
    {
        //注入用户管理操作
        private INoticeRepository noticeRepository { get; set; }
		public NoticeService(INoticeRepository _noticeRepository)
        {
            noticeRepository = _noticeRepository;
        }

        public async Task<Pager<IQueryable<NoticeEntity>>> List(NoticeInfo noticeInfo)
        {
            //判断查询参数
            Expression<Func<NoticeEntity, bool>> where = LinqUtil.True<NoticeEntity>();
            if (!string.IsNullOrEmpty(noticeInfo.notice_desc))
            {
                where = where.AndAlso(c => c.notice_desc.Contains(noticeInfo.notice_desc));
            }
            if (noticeInfo.disable != -1)
            {
                where = where.AndAlso(c => c.disable == noticeInfo.disable);
            }

            //调用仓储方法查询分页并且响应给前台
            int total = await noticeRepository.CountAsync(where);

            IQueryable<NoticeEntity> list = await noticeRepository.GetPageAllAsync<NoticeEntity, DateTime, NoticeEntity>(
                noticeInfo.pageindex, noticeInfo.pagesize, where, c => c.createtime, null, false);

            return new Pager<IQueryable<NoticeEntity>>(total, list.AsQueryable());
        }

        public async Task<BaseResult<IQueryable<DropDownList>>> listNoDisable()
        {
            IQueryable<NoticeEntity> data = await noticeRepository.GetAllAsync(c => c.disable == 0);
            var result = from n in data
                         select new DropDownList
                         {
                             value = n.notice_id,
                             name = n.notice_desc
                         };
            return new BaseResult<IQueryable<DropDownList>>(200, result);
        }

        public async Task<BaseResult<NoticeEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<NoticeEntity>(808);
            }

            var noticeEntity = await noticeRepository.GetAsync(c => c.notice_id == id);
            if (noticeEntity == null)
            {
                return new BaseResult<NoticeEntity>(202);
            }
            return new BaseResult<NoticeEntity>(200, noticeEntity);
        }

        public async Task<BaseResult<bool>> Add(NoticeEntity noticeEntity)
        {
            //在添加之前首先判断数据库中是否含有同名的数据，如果含有数据则不允许插入
            int count = await noticeRepository.CountAsync(c => c.notice_desc == noticeEntity.notice_desc && c.notice_id != "0");
            if (count >= 1)
            {
                return new BaseResult<bool>(900, false);
            }
            var isTrue = await noticeRepository.AddAsync(noticeEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Update(NoticeEntity noticeEntity)
        {
            //在修改之前首先判断数据库中是否含有同名的数据，如果含有数据则不允许插入
            int count = await noticeRepository.CountAsync(c => c.notice_desc == noticeEntity.notice_desc && c.notice_id != noticeEntity.notice_id);
            if (count >= 1)
            {
                return new BaseResult<bool>(900, false);
            }

            var isTrue = await noticeRepository.UpdateAsync(noticeEntity, true, true, c => c.notice_desc, c => c.notice_desc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string notice_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(notice_id))
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            NoticeEntity noticeEntity = await noticeRepository.GetAsync(c => c.notice_id.Equals(notice_id));
            if (string.IsNullOrEmpty(noticeEntity.disabledesc))
            {
                str = "{'disable':'" + noticeEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = noticeEntity.disabledesc + ",{'disable':'" + noticeEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            NoticeEntity notice = new NoticeEntity()
            {
                notice_id = notice_id,
                disabledesc = str,
                disable = type
            };

            var isTrue = await noticeRepository.UpdateAsync(notice, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

    }
}