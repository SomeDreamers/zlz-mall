//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopCommentInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/30 16:23:54
//  网站：				  		http://www.chuxinm.com
//==============================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 查看商品评论信息
    /// </summary>
    public class ShopCommentInfo
    {
        /// <summary>
        /// 评论Id
        /// </summary>
        [Key]
        public string comment_id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string user_image { get; set; }

        /// <summary>
        /// 商品Code
        /// </summary>
        public string shop_code { get; set; }

        /// <summary>
        /// 商品评论内容
        /// </summary>
        public string comment_desc { get; set; }

        /// <summary>
        /// 管理员回复内容
        /// </summary>
        public string comment_reply { get; set; }

        /// <summary>
        /// 评论等级
        /// </summary>
        public int comment_star { get; set; }

        /// <summary>
        /// 商品评论地址
        /// </summary>
        public string comment_address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime { get; set; }
    }
}