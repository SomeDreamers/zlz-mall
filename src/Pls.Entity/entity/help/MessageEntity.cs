//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Entity/MessageEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 系统留言表实体
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// 系统留言表Id-主键
        /// </summary>
        public string message_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 可空  可空为游客，传递则为注册人
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string message_desc { get; set; }

        /// <summary>
        /// 留言类型(1:网站前端意见,2:后端意见)
        /// </summary>
        public int message_type { get; set; } = (int)MessageType.website;

        /// <summary>
        /// 是否已读(0：未读，1:已读)
        /// </summary>
        public int message_read { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        /// 是否解决(0：未，1:已)
        /// </summary>
        public int message_solve { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        ///  可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}