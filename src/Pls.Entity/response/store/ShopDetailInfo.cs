//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopDetailInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 16:25:30
//  网站：				  		http://www.chuxinm.com
//==============================================================

using System.Linq;

namespace Pls.Entity
{
    /// <summary>
    /// 商品详情页展示
    /// </summary>
    public class ShopDetailInfo
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public ShopEntity shopEntity { get; set; }

        /// <summary>
        /// 商品SKU信息
        /// </summary>
        public IQueryable<ShopSkuEntity> ShopSkuEntitys { get; set; }

        /// <summary>
        /// 商品SKU信息单个实体
        /// </summary>
        public ShopSkuEntity shopSkuEntity { get; set; }

        /// <summary>
        /// 商品属性实体
        /// </summary>
        public ShopAttrEntity shopAttrEntity { get; set; }

        /// <summary>
        /// 商品SKU对应的图片信息
        /// </summary>
        public IQueryable<ShopImageEntity> shopImageEntitys { get; set; }

        /// <summary>
        /// 商品优惠信息
        /// </summary>
        public ShopCouponEntity shopCouponEntity { get; set; }
    }
}