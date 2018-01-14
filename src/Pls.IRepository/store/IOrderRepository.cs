//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.IRepository/IOrderRepository 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/23 23:31:32
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 订单管理操作类接口
    /// </summary>
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        /// <summary>
        /// 根据查询条件查询订单信息
        /// </summary>
        /// <param name="where_search">查询条件</param>
        /// <returns></returns>
        Task<IQueryable<OrderPay>> GetOrderPay(Expression<Func<OrderPay, bool>> where_search);

        /// <summary>
        /// 查询订单列表信息
        /// </summary>
        /// <param name="where_search"></param>
        /// <returns></returns>
        Task<IQueryable<OrderPay>> OrderListInfo(Expression<Func<OrderPay, bool>> where_search);
    }
}