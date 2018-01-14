//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/CartOrders 
//  创建人:                     kencery     
//  创建时间:                   2016/11/26 21:27:05
//  网站:                       http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 购物车下订单到订单表实体
    /// </summary>
    public class CartOrders
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品Sku Id
        /// </summary>
        public string shopsku_id { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int shop_count { get; set; }
    }
}