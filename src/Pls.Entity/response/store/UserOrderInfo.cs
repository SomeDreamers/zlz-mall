//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Entity/UserOrderInfo 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/25 23:45:07
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Entity.response;
using System.Linq;

namespace Pls.Entity
{
    public class UserOrderInfo : OrderEntity
    {
        /// <summary>
        /// 创建人邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public IQueryable<OrderDetailEntity> orderdetail { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public IQueryable<OrderDetailInfo> orderdetailinfo { get; set; }

    }
}