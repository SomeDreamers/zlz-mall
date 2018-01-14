//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 13:35:42
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 评论产品表(Pls_Comment)—>购买之后才有权限评论
    /// </summary>
    public class CommentEntity
    {
        /// <summary>
        ///  评论产品表Id-主键
        /// </summary>
        public string comment_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 用户Id，不可空，可空不能评论
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品skuId
        /// </summary>
        public string shopsku_id { get; set; }

        /// <summary>
        /// 默认5 评价级别：(总共5星)
        /// </summary>
        public int comment_star { get; set; } = 5;

        /// <summary>
        /// 评论内容
        /// </summary>
        public string comment_desc { get; set; }

        /// <summary>
        /// 默认0 父userId,第一个为0，回复的时候为user_id
        /// </summary>
        public string parant_userid { get; set; } = "0";

        /// <summary>
        /// 回复内容    登录管理员回复的内容
        /// </summary>
        public string comment_reply { get; set; }

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