//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.Service/MessageService 
//  创建人:                     Brian     
//  创建时间:                   9/24/2016 9:38:48 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

using Pls.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IRepository;
using System.Linq.Expressions;
using Pls.Utils;

namespace Pls.Service
{
    /// <summary>
    ///  留言管理业务接口
    /// </summary>
    public class MessageService : IMessageService
    {
        //注入留言管理操作
        private IMessageRepository messageRepository { get; set; }
        private IUserRepository userRepository { get; set; }
        public MessageService(IMessageRepository _messageRepository, IUserRepository _userRepository)
        {
            messageRepository = _messageRepository;
            userRepository = _userRepository;
        }

        public async Task<Pager<IQueryable<MessageShowInfo>>> List(MessageInfo messageInfo)
        {
            //判断查询参数
            Expression<Func<UserEntity, bool>> userwhere_serach = LinqUtil.True<UserEntity>();
            Expression<Func<MessageEntity, bool>> where_serach = LinqUtil.True<MessageEntity>();
            if (!string.IsNullOrEmpty(messageInfo.user_email))
            {
                userwhere_serach = userwhere_serach.AndAlso(b => b.user_email.Contains(messageInfo.user_email));
            }
            if ((messageInfo.disable_status) != -1)
            {
                where_serach = where_serach.AndAlso(b => b.disable == messageInfo.disable_status);
            }

            int total = await messageRepository.CountAsync(where_serach);
            int pageindex = messageInfo.pageindex;              //页码，因为没有set，所以就重新定义一个变量

            //调用仓储方法查询分页并且响应给前台
            IQueryable<MessageShowInfo> query = (from c in await messageRepository.GetAllAsync(where_serach)
                                                 join o in await userRepository.GetAllAsync(userwhere_serach) on c.user_id equals o.user_id into temp
                                                 from leftjoin in temp.DefaultIfEmpty()
                                                 select new MessageShowInfo()
                                                 {
                                                     user_email = leftjoin == null ? "" : leftjoin.user_email, //不需要创建实体，世界使用用户Id显示用户邮箱   
                                                     user_name = leftjoin == null ? "" : leftjoin.user_name, //不需要创建实体，世界使用用户Id显示用户邮箱
                                                     user_image = leftjoin == null ? "" : leftjoin.user_image,
                                                     createtime = c.createtime,
                                                     disable = c.disable,
                                                     disabledesc = c.disabledesc,
                                                     message_desc = c.message_desc,
                                                     message_id = c.message_id,
                                                     message_read = c.message_read,
                                                     message_solve = c.message_solve,
                                                     message_type = c.message_type,
                                                     row_number = c.row_number
                                                 }).OrderByDescending(c => c.createtime).Skip((--pageindex * messageInfo.pagesize)).Take(messageInfo.pagesize);

            return new Pager<IQueryable<MessageShowInfo>>(total, query);
        }

        public async Task<BaseResult<MessageShowInfo>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<MessageShowInfo>(808);
            }

            IQueryable<MessageShowInfo> query = (from c in await messageRepository.GetAllAsync(c => c.message_id == id)
                                                 join o in await userRepository.GetAllAsync() on c.user_id equals o.user_id into temp
                                                 from leftjoin in temp.DefaultIfEmpty()
                                                 select new MessageShowInfo()
                                                 {
                                                     user_email = leftjoin == null ? "" : leftjoin.user_email, //不需要创建实体，世界使用用户Id显示用户邮箱   
                                                     user_name = leftjoin == null ? "" : leftjoin.user_name, //不需要创建实体，世界使用用户Id显示用户邮箱
                                                     user_image = leftjoin == null ? "" : leftjoin.user_image,
                                                     createtime = c.createtime,
                                                     disable = c.disable,
                                                     disabledesc = c.disabledesc,
                                                     message_desc = c.message_desc,
                                                     message_id = c.message_id,
                                                     message_read = c.message_read,
                                                     message_solve = c.message_solve,
                                                     message_type = c.message_type,
                                                     row_number = c.row_number
                                                 });

            var messageEntity = query.FirstOrDefault();
            if (messageEntity == null)
            {
                return new BaseResult<MessageShowInfo>(202);
            }
            return new BaseResult<MessageShowInfo>(200, messageEntity);
        }

        public BaseResult<string> GetMessageTypeNameByMsgType(string messageType)
        {
            if (string.IsNullOrEmpty(messageType))
            {
                return new BaseResult<string>(808);
            }
            string msgType = string.Empty;
            switch (messageType)
            {
                case "1":
                    msgType = "网站意见";
                    break;
                default:
                    msgType = "网站意见";
                    break;
            }
            return new BaseResult<string>(200, msgType);
        }

        public async Task<BaseResult<bool>> Add(string userid, string message_desc)
        {
            MessageEntity messageEntity = new MessageEntity()
            {
                user_id = userid,
                message_desc = message_desc,
                message_type = 1,
                message_read = 0,
                message_solve = 0
            };
            var isTrue = await messageRepository.AddAsync(messageEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Update(MessageEntity messageEntity)
        {
            var isTrue = await messageRepository.UpdateAsync(messageEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> UpdateRead(string[] idList)
        {
            try
            {
                foreach (var item in idList)
                {
                    var messageEntity = await messageRepository.GetAsync(c => c.message_id == item);
                    if (messageEntity == null)
                    {
                        return new BaseResult<bool>(202, false);
                    }
                    messageEntity.message_read = 0;
                    var isTrue = await messageRepository.UpdateAsync(messageEntity);
                    if (!isTrue)
                    {
                        return new BaseResult<bool>(201, false);
                    }
                }
                return new BaseResult<bool>(200, true);
            }
            catch (Exception)
            {
                return new BaseResult<bool>(201, false);
            }
        }

        public async Task<BaseResult<bool>> Disable(string[] message_id, string disable_desc, int type)
        {
            if (message_id.Length <= 0)
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            List<MessageEntity> list = new List<MessageEntity>();
            MessageEntity vmodel = null;
            foreach (var item in message_id)
            {
                var messageEntity = await messageRepository.GetAsync(c => c.message_id.Equals(item));
                if (string.IsNullOrEmpty(messageEntity.disabledesc))
                {
                    str = "{'disable':'" + messageEntity.disable + "','disable_desc':'" + disable_desc + "'}";
                }
                else
                {
                    str = messageEntity.disabledesc + ",{'disable':'" + messageEntity.disable + "','disable_desc':'" + disable_desc + "'}";
                }
                vmodel = new MessageEntity()
                {
                    message_id = item,
                    disabledesc = str,
                    disable = type
                };
                list.Add(vmodel);
            }

            var isTrue = await messageRepository.UpdateListAsync(list, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> SetResolve(string[] idList)
        {
            try
            {
                foreach (var item in idList)
                {
                    var messageEntity = await messageRepository.GetAsync(c => c.message_id == item);
                    if (messageEntity == null)
                    {
                        return new BaseResult<bool>(202, false);
                    }
                    messageEntity.message_solve = 0;
                    var isTrue = await messageRepository.UpdateAsync(messageEntity);
                    if (!isTrue)
                    {
                        return new BaseResult<bool>(201, false);
                    }
                }
                return new BaseResult<bool>(200, true);
            }
            catch (Exception)
            {
                return new BaseResult<bool>(201, false);
            }
        }

        public async Task<BaseResult<bool>> Delete(string[] messge_id)
        {
            if (messge_id == null || messge_id.Length < 1)
            {
                return new BaseResult<bool>(808);
            }
            var isTrue = false;
            foreach (var item in messge_id)
            {
                isTrue = await messageRepository.DeleteAsync(new MessageEntity
                {
                    message_id = item
                });
            }

            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }
    }
}