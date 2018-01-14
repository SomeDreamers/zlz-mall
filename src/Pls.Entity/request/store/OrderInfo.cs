//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Entity/OrderInfo 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/25 23:22:59
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    public class OrderInfo : PageEntity
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string order_number { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public int order_paystatus { get; set; }

        /// <summary>
        /// 禁用状态
        /// </summary>
        public int disable { get; set; }
    }
}