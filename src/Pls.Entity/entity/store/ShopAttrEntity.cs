//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopAttrEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/16 11:25:17
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 商品属性表实体(Pls_ShopAttr)
    /// </summary>
    public class ShopAttrEntity
    {
        /// <summary>
        /// 商品属性Id-主键
        /// </summary>
        public string shopattr_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 商品Id（外键）
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        ///  可空  商品开发者
        /// </summary>
        public string shopattr_author { get; set; }

        /// <summary>
        /// 可空  开发语言
        /// </summary>
        public string shopattr_language { get; set; }

        /// <summary>
        /// 可空  开发环境
        /// </summary>
        public string shopattr_condition { get; set; }

        /// <summary>
        /// 可空  数据库
        /// </summary>
        public string shopattr_database { get; set; }

        /// <summary>
        /// 可空  商品的架构比如C/S B/S
        /// </summary>
        public string shopattr_framework { get; set; }

        /// <summary>
        /// 可空  版本工具管理
        /// </summary>
        public string shopattr_manage { get; set; }

        /// <summary>
        /// 可空  大小(M)
        /// </summary>
        public double shopattr_size { get; set; } = 0;

        /// <summary>
        ///  可空  编码格式
        /// </summary>
        public string shopattr_utf { get; set; }

        /// <summary>
        /// 可空  演示网站地址
        /// </summary>
        public string shopattr_weburl { get; set; }

        /// <summary>
        /// 可空  博客地址
        /// </summary>
        public string shopattr_blogaddress { get; set; }

        /// <summary>
        ///  可空  是否开源
        /// </summary>
        public bool shopattr_isopensource { get; set; } = false;

        /// <summary>
        ///  可空  开源协议
        /// </summary>
        public string shopattr_opensource { get; set; }

        /// <summary>
        /// 可空  商品备注
        /// </summary>
        public string shopattr_memo { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}