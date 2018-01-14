//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Repository/OrderRepository 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/23 23:40:45
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.EntityFrameworkCore;
using Pls.Entity;
using Pls.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pls.Repository
{
    /// <summary>
    /// 订单管理操作类
    /// </summary>
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }

        public Task<IQueryable<OrderPay>> GetOrderPay(Expression<Func<OrderPay, bool>> where_search)
        {
            const string sql = @"SELECT porder.order_id,porder.order_number,porder.order_total,porder.order_privilege,porder.order_actualpay,porder.order_delete,
			porder.order_goods,porder.order_paystatus,porder.createtime,porder.order_payway,porder.user_id AS user_id,
			shop.shop_name,shopsku.shop_code,shop.shop_defaultimg,shopsku.shopsku_id,shop.shop_id,
			orderdetail.shop_count,orderdetail.shop_currentprice,orderdetail.orderdetail_id,orderdetail.orderdetail_delete,orderdetail.orderdetail_evaluate,
			shopcoupon.shopcoupon_type,shopcoupon.shopcoupon_name,shopcoupon.shopcoupon_money
		FROM Pls_Order AS porder
				INNER JOIN Pls_OrderDetail AS orderdetail ON porder.order_id = orderdetail.order_id
				INNER JOIN Pls_Shop AS shop ON orderdetail.shop_id = shop.shop_id
				INNER JOIN Pls_ShopSku AS shopsku ON orderdetail.shopsku_id = shopsku.shopsku_id
				LEFT JOIN (SELECT * from Pls_ShopCoupon where `disable`=0 AND endtime>NOW()) AS shopcoupon ON shop.shop_id = shopcoupon.shop_id
		WHERE porder.`disable`= 0 ";
            IQueryable<OrderPay> orderPays = ctx.OrderPays.AsTracking().FromSql(sql).Where(where_search);

            return Task.Run(() => orderPays.OrderByDescending(c => c.createtime).AsNoTracking());
        }

        public Task<IQueryable<OrderPay>> OrderListInfo(Expression<Func<OrderPay, bool>> where_search)
        {
            const string sql = @"SELECT porder.order_id,porder.order_number,porder.order_total,porder.order_privilege,porder.order_actualpay,porder.order_delete,
                porder.order_goods,porder.order_paystatus,porder.createtime,porder.order_payway,porder.user_id AS user_id,
                shop.shop_name,shopsku.shop_code,shop.shop_defaultimg,shopsku.shopsku_id,shop.shop_id,
                orderdetail.shop_count,orderdetail.shop_currentprice,orderdetail.orderdetail_id,orderdetail.orderdetail_delete,orderdetail.orderdetail_evaluate,
				shopcoupon.shopcoupon_type,shopcoupon.shopcoupon_name,shopcoupon.shopcoupon_money
		    FROM Pls_Order AS porder
		        INNER JOIN Pls_OrderDetail AS orderdetail ON porder.order_id = orderdetail.order_id
		        INNER JOIN Pls_Shop AS shop ON orderdetail.shop_id = shop.shop_id
		        INNER JOIN Pls_ShopSku AS shopsku ON orderdetail.shopsku_id = shopsku.shopsku_id
		        LEFT JOIN Pls_ShopCoupon AS shopcoupon ON orderdetail.shopcoupon_id = shopcoupon.shopcoupon_id
		    WHERE porder.`disable`= 0";
            IQueryable<OrderPay> orderPays = ctx.OrderPays.AsTracking().FromSql(sql).Where(where_search);

            return Task.Run(() => orderPays.OrderByDescending(c => c.createtime).AsNoTracking());
        }
    }
}