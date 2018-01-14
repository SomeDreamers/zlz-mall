//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.IService/IMessageService 
//  创建人:                     Brian     
//  创建时间:                   9/24/2016 9:34:24 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    ///  留言管理业务接口
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// 异步查询留言列表
        /// </summary>
        /// <param name="messageInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<MessageShowInfo>>> List(MessageInfo messageInfo);

        /// <summary>
        /// 根据主键Id查询留言信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<MessageShowInfo>> GetById(string id);

        /// <summary>
        /// 根据留言类型Id获取留言类型名称
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        BaseResult<string> GetMessageTypeNameByMsgType(string messageType);

        /// <summary>
        /// 添加留言实现
        /// </summary>
        /// <param name="userid">用户Id</param>
        /// <param name="message_desc">留言内容</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(string userid, string message_desc);

        /// <summary>
        /// 留言修改
        /// </summary>
        /// <param name="messageEntity">留言条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Update(MessageEntity messageEntity);

        /// <summary>
        /// 留言修改成已读
        /// </summary>
        /// <param name="idList">修改条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateRead(string[] idList);

        /// <summary>
        /// 留言禁用
        /// </summary>
        /// <param name="message_id">Id</param>
        /// <param name="disable_desc">留言描述</param>
        /// <param name="type">启用禁用类型</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string[] message_id, string disable_desc, int type);

        /// <summary>
        /// 留言修改成已解决
        /// </summary>
        /// <param name="idList">修改条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> SetResolve(string[] idList);

        /// <summary>
        /// 留言删除
        /// </summary>
        /// <param name="messge_id">留言主键</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Delete(string[] messge_id);
    }
}