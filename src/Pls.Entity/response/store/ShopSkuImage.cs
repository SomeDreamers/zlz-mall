//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopSkuImage 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/19 2:58:15
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 返回商品SKU的内容
    /// </summary>
    public class ShopSkuImage : ShopImageEntity
    {
        /// <summary>
        /// 商品SKU名称
        /// </summary>
        public string shopsku_name { get; set; }
    }
}