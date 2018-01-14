//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Entity.response/OrderDetailInfo 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/12/12 22:42:47
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Entity.response
{
    public class OrderDetailInfo
    {
        public string orderdetail_id { get; set; }

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
        /// 商品数量
        /// </summary>
        public int shop_count { get; set; } = 1;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string shop_number { get; set; }

        /// <summary>
        /// 商品Code（v1.0.0）
        /// </summary>
        public string shop_code { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        public string shopsku_originalprice { get; set; }

        /// <summary>
        /// 商品默认图片
        /// </summary>
        public string shop_defaultimg { get; set; }
    }
}
