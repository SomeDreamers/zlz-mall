//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CommentShop 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/7 17:40:42
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Collections.Generic;

namespace Pls.Entity
{
    /// <summary>
    /// 商品评论添加实体
    /// </summary>
    public class CommentShop
    {
        /// <summary>
        /// 用户Id，不可空，可空不能评论
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 订单详情表Id
        /// </summary>
        public string orderdetail_id { get; set; }

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
        public int comment_star { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string comment_desc { get; set; }

        /// <summary>
        /// 图片地址集合
        /// </summary>
        public List<string> image_url { get; set; }
    }
}