//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopImageEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:40:59
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品图片表实体(Pls_ShopImage)
    /// </summary>
    public class ShopImageEntity
    {
        /// <summary>
        /// 商品图片Id-主键
        /// </summary>
        public string shopimage_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 商品Id（外键）
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品SKUId（外键）
        /// </summary>
        public string shopsku_id { get; set; }

        /// <summary>
        /// 商品图片地址
        /// </summary>
        public string shopimage_address { get; set; }

        /// <summary>
        /// 默认false 是否默认
        /// </summary>
        public bool shopimage_default { get; set; }

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