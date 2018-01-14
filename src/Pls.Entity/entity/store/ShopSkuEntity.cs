//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopSkuEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:00:53
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品SKU表实体(Pls_ShopSku)
    /// </summary>
    public class ShopSkuEntity
    {
        /// <summary>
        /// 商品SKU Id-主键
        /// </summary>
        public string shopsku_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 商品Id（外键）
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品Code（v1.0.0）
        /// </summary>
        public string shop_code { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        public string shopsku_originalprice { get; set; }

        /// <summary>
        /// 商品会员价
        /// </summary>
        public string shopsku_currentprice { get; set; }

        /// <summary>
        /// 商品下载地址
        /// </summary>
        public string shopsku_url { get; set; }

        /// <summary>
        /// 商品下载地址对应的下载码
        /// </summary>
        public string shopsku_code { get; set; }

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

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