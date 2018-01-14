//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Repository/OrderDetailRepository 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/23 23:46:19
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using Pls.IRepository;

namespace Pls.Repository
{
    /// <summary>
    /// 订单详情管理操作类
    /// </summary>
    public class OrderDetailRepository:BaseRepository<OrderDetailEntity>,IOrderDetailRepository
    {
        public OrderDetailRepository(DataContext context) : base(context)
        {

        }
    }
}
