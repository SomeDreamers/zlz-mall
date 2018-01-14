//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.IService/IOrderService 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/23 23:51:14
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using Pls.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Pls.IService
{
    /// <summary>
    /// 订单管理业务接口
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 根据查询条件异步查询订单信息
        /// </summary>
        /// <param name="orderInfo">查询条件实体</param>
        /// <returns></returns>
        Task<Pager<IQueryable<UserOrderInfo>>> List(OrderInfo orderInfo);

        /// <summary>
        /// 根据订单Id查询订单信息以及订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<UserOrderInfo>> GetOrderById(string id);

        /// <summary>
        /// 订单支付页面-根据订单Id查询出商品的信息
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <param name="user_id">用户ID</param>
        /// <returns></returns>
        Task<IQueryable<OrderPay>> getOrderPay(string id, string user_id);

        /// <summary>
        /// 订单查询中心根据用户Id查询
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="type">类型(1:全部，2:待付款，3:待收货)</param>
        /// <returns></returns>
        Task<Pager<IQueryable<OrderPay>>> OrderListByUserId(string user_id, int type, string order_id = "0");

        /// <summary>
        /// 评价晒单和追加评价
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="order_id">订单Id</param>
        /// <param name="shopsku_id">商品SKU_Id</param>
        /// <returns></returns>
        Task<OrderPay> OrderInfoByShopSkuId(string user_id, string order_id, string shopsku_id);

        /// <summary>
        /// 根据订单Id查询需要升级的订单信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<DropDownList>>> ShopskuList(string shop_id);

        /// <summary>
        /// 根据商品SKUId查询商品价钱
        /// </summary>
        /// <param name="shopsku_id">原始购买的商品Id</param>
        /// <param name="shopsku_id">重新选择后的商品Id</param>
        /// <returns></returns>
        Task<BaseResult<string>> ShopMoneyBySkuId(string shopsku_id, string check_shopsku_id);

        /// 添加订单信息
        /// </summary>
        /// <param name="orders">订单</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task<BaseResult<string>> AddOrder(List<CartOrders> orders, string userId);

        /// <summary>
        /// 设置订单支付
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="payway">支付方式</param>
        /// <param name="sendMailConfig">发送邮箱</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Pay(string order_id, int payway, SendMailConfig sendMailConfig);

        /// <summary>
        /// 升级系统方法实现
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="check_shopsku_id">选择的商品SKUId</param>
        /// <param name="shopsku_id">原始的商品SKUId</param>
        /// <param name="sendMailConfig">发送邮箱</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpgradeOrder(string order_id, string check_shopsku_id, string shopsku_id, SendMailConfig sendMailConfig);

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="order_memo">订单备注</param>
        /// <param name="isprivilege">是否优惠</param>
        /// <returns></returns>
        Task<BaseResult<bool>> PayOrder(string order_id, string order_memo, bool isprivilege);

        /// <summary>
        /// 订单启用禁用管理
        /// </summary>
        /// <param name="order_id">订单id</param>
        /// <param name="disable_desc">禁用启用描述</param>
        /// <param name="type">启用禁用类型(0:启用，1：禁用)</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string order_id, string disable_desc, int type);

        /// <summary>
        /// 根据订单详情Id删除订单信息
        /// </summary>
        /// <param name="orderdetail_id">订单详情Id</param>
        /// <param name="order_id">订单Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> DeleteOrderDetail(string orderdetail_id, string order_id);

        /// <summary>
        /// 根据订单Id对主表进行修改—确认收货订单
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateOkGoods(string order_id);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="order_id">订单id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Delete(string order_id);

        /// <summary>
        /// 收入金额(已支付的订单统计)
        /// </summary>
        /// <returns></returns>
        Task<string> IncomeMoney();
    }
}