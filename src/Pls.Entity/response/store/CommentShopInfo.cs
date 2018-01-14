//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentShopInfo 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/3 22:32:24
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System;
using System.Linq;

namespace Pls.Entity
{
    public class CommentShopInfo
    {

        /// <summary>
        /// 评论id
        /// </summary>
        public string comment_id { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 默认5 评价级别：(总共5星)
        /// </summary>
        public int comment_star { get; set; } = 5;

        /// <summary>
        /// 评论内容
        /// </summary>
        public string comment_desc { get; set; }

        /// <summary>
        /// 回复内容    登录管理员回复的内容
        /// </summary>
        public string comment_reply { get; set; }

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; }

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; }

        /// <summary>
        ///  可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 返回评论的图片集合
        /// </summary>
        public IQueryable<string> commentImage { get; set; }
    }
}