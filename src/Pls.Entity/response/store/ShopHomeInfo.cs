//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/ShopHomeInfo 
//  创建人:                     kencery     
//  创建时间:                   2016/11/19 21:43:41
//  网站:                       http://www.chuxinm.com
//==============================================================
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品首页查询返回实体
    /// </summary>
    public class ShopHomeInfo
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        [Key]
        public string shop_id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string shop_defaultimg { get; set; }

        /// <summary>
        /// 商品是否优惠
        /// </summary>
        public bool shop_isdiscount { get; set; }

        /// <summary>
        /// 商品创建时间
        /// </summary>
        public DateTime createtime { get; set; }

        /// <summary>
        /// 商品的第一个版本的价钱
        /// </summary>
        public string shop_money { get; set; }

        /// <summary>
        /// 商品购买人数
        /// </summary>
        public int? shop_paycount { get; set; }
    }
}