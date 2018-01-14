//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopCouponEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:48:38
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品优惠表实体(Pls_ShopCoupon)
    /// </summary>
    public class ShopCouponEntity
    {
        /// <summary>
        /// 商品优惠Id-主键
        /// </summary>
        public string shopcoupon_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 商品Id（外键）
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品优惠类别
        /// </summary>
        public string shopcoupon_type { get; set; }

        /// <summary>
        /// 商品优惠名称
        /// </summary>
        public string shopcoupon_name { get; set; }

        /// <summary>
        /// 商品优惠额度
        /// </summary>
        public double shopcoupon_money { get; set; }

        /// <summary>
        ///  创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        ///  结束时间(自行设置，不能为空)
        /// </summary>
        public DateTime endtime { get; set; }

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}