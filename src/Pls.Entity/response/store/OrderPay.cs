//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Entity/OrderPay 
//  创建人:                     kencery     
//  创建时间:                   2016/11/28 21:42:42
//  网站:                       http://www.chuxinm.com
//==============================================================
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 支付确认订单信息
    /// </summary>
    public class OrderPay
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        [Key]
        public string order_id { get; set; }

        /// <summary>
        /// 订单详情Id
        /// </summary>
        public string orderdetail_id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string order_number { get; set; }

        /// <summary>
        /// 订单总额
        /// </summary>
        public double? order_total { get; set; }

        /// <summary>
        /// 订单总优惠
        /// </summary>
        public double? order_privilege { get; set; }

        /// <summary>
        /// 订单实际支付金额
        /// </summary>
        public double? order_actualpay { get; set; }

        /// <summary>
        /// 删除状态(1:未删除 2:删除回收站 3:彻底删除)
        /// </summary>
        public int order_delete { get; set; }

        /// <summary>
        /// 发货状态(1:未发货 2:已发货 3:确认收货)
        /// </summary>
        public int order_goods { get; set; }

        /// <summary>
        /// 支付状态(1:未支付 2:已支付)
        /// </summary>
        public int order_paystatus { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime createtime { get; set; }

        /// <summary>
        /// 订单详情删除状态(1:未删除 2:删除回收站 3:彻底删除)
        /// </summary>
        public int orderdetail_delete { get; set; }

        /// <summary>
        /// 是否评价(1:未评价 2:已评价)
        /// </summary>
        public int orderdetail_evaluate { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public string shop_id { get; set; }

        /// <summary>
        /// 商品SKU_Id
        /// </summary>
        public string shopsku_id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 商品code
        /// </summary>
        public string shop_code { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public double shop_currentprice { get; set; }

        /// <summary>
        /// 商品默认图片
        /// </summary>
        public string shop_defaultimg { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int shop_count { get; set; }

        /// <summary>
        /// 商品支付方式
        /// </summary>
        public int order_payway { get; set; }

        /// <summary>
        /// 商品优惠类别
        /// </summary>
        public string shopcoupon_type { get; set; }

        /// <summary>
        /// 商品优惠名称
        /// </summary>
        public string shopcoupon_name { get; set; }

        /// <summary>
        /// 商品优惠金钱
        /// </summary>
        public double? shopcoupon_money { get; set; }
    }
}