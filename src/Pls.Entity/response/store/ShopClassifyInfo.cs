//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopClassifyInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/21 13:03:42
//  网站：				  		http://www.chuxinm.com
//==============================================================

using System.Linq;

namespace Pls.Entity
{
    /// <summary>
    /// 商品分类展示到前台的信息
    /// </summary>
    public class ShopClassifyInfo
    {
        /// <summary>
        /// 页面类别，根据type参数构造完成(type=4则走另外的html，否则则走同一个html了) 0:首页集合  1：详情页集合
        /// </summary>
        public int page_type { get; set; }

        /// <summary>
        /// 返回的商品信息
        /// </summary>
        public IQueryable<ShopHomeInfo> shopHomeInfos { get; set; }
    }
}