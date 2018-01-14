//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 10:32:06
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品表实体(Pls_Shop)
    /// </summary>
    public class ShopEntity
    {
        /// <summary>
        /// 商品Id-主键
        /// </summary>
        public string shop_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 商品备注(一句话简易描述),限制25个字以内
        /// </summary>
        public string shop_memo { get; set; }

        /// <summary>
        /// 商品编号(后台自动生成,不允许修改)
        /// </summary>
        public string shop_number { get; set; } = CommonUtil.ReadRandom("#", 8, 9) + "_" + CommonUtil.ReadRandom("", 3, 9);

        /// <summary>
        /// 商品详情(详情说明)
        /// </summary>
        public string shop_desc { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string shop_defaultimg { get; set; }

        /// <summary>
        /// (默认false)	是否优惠，如果优惠，则前台拆红包，否则无
        /// </summary>
        public bool shop_isdiscount { get; set; } = false;

        /// <summary>
        /// 商品创建人：session中读取
        /// </summary>
        public string user_id { get; set; }

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