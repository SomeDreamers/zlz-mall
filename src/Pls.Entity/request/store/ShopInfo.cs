//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/17 9:40:37
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 商品管理查询实体
    /// </summary>
    public class ShopInfo : PageEntity
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string shop_number { get; set; }

        /// <summary>
        /// 是否优惠
        /// </summary>
        public int shop_isdiscount { get; set; }

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; }

    }
}