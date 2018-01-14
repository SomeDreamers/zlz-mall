//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/OrderEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/22 11:37:29
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 订单主表实体(Pls_Order)
    /// </summary>
    public class OrderEntity
    {
        /// <summary>
        /// 主键-GUID()
        /// </summary>
        public string order_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 订单编号_时间戳+随机数(自动生成11位)
        /// </summary>
        public string order_number { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + CommonUtil.ReadRandom("", 4, 9);

        /// <summary>
        /// 可为0 订单总价钱
        /// </summary>
        public double order_total { get; set; }

        /// <summary>
        /// 可为0 订单总优惠
        /// </summary>
        public double order_privilege { get; set; }

        /// <summary>
        /// 可为0 订单实际支付金额(总价钱-总优惠)
        /// </summary>
        public double order_actualpay { get; set; }

        /// <summary>
        /// 默认1 支付状态(1:未支付 2:已支付)
        /// </summary>
        public int order_paystatus { get; set; } = 1;

        /// <summary>
        /// 默认1 支付方式(1:支付宝支付 2:微信支付)
        /// </summary>
        public int order_payway { get; set; } = 1;

        /// <summary>
        /// 默认1 发货状态(1:未发货 2:已发货 3:确认收货)
        /// </summary>
        public int order_goods { get; set; } = 1;

        /// <summary>
        /// 默认1 删除状态(1:未删除 2:删除回收站 3:彻底删除)
        /// </summary>
        public int order_delete { get; set; } = 1;

        /// <summary>
        /// 可空 订单备注
        /// </summary>
        public string order_memo { get; set; }

        /// <summary>
        /// 创建人
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
        /// 可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}