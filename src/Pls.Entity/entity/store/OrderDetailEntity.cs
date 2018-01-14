//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/OrderDetailEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 11:38:24
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 订单详情表实体(Pls_OrderDetail)
    /// </summary>
    public class OrderDetailEntity
    {

        /// <summary>
        /// 主键-GUID()
        /// </summary>
        public string orderdetail_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 订单主表Id
        /// </summary>
        public string order_id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品skuId
        /// </summary>
        public string shopsku_id { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public double shop_currentprice { get; set; }

        /// <summary>
        /// 默认0 商品优惠Id，不选中则为0
        /// </summary>
        public string shopcoupon_id { get; set; } = "0";

        /// <summary>
        /// 商品数量，默认1
        /// </summary>
        public int shop_count { get; set; } = 1;

        /// <summary>
        /// 默认1 删除状态(1:未删除 2:删除回收站 3:彻底删除)
        /// </summary>
        public int orderdetail_delete { get; set; } = 1;

        /// <summary>
        ///是否评价(1:未评价 2:已评价)
        /// </summary>
        public int orderdetail_evaluate { get; set; } = 1;

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}