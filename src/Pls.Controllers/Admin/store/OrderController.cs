//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	SHANGWW-PC
//  命名空间名称/文件名:    	Pls.Controllers.Admin/OrderController 
//  创建人:			   	  		ShangW     
//  创建时间:     		  		2016/11/23 23:56:56
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 订单管理控制器的实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Order")]
    [Login]
    [AjaxOnly]
    public class OrderController : BaseController
    {
        //注入
        public IOrderService orderService;
        public OrderController(ApplicationConfigServices _applicationConfigServices, IOrderService _orderService)
            : base(_applicationConfigServices)
        {
            orderService = _orderService;
        }

        /// <summary>
        /// 订单信息首页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据查询条件异步查询订单信息
        /// </summary>
        /// <param name="orderInfo">查询实体</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(OrderInfo orderInfo)
        {
            var data = await orderService.List(orderInfo);
            return JsonDate(data);
        }

        /// 根据订单Id查询订单信息以及订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var data = await orderService.GetOrderById(id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 根据订单Id查询需要升级的订单信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("ShopskuList")]
        public async Task<IActionResult> ShopskuList(string shop_id)
        {
            var data = await orderService.ShopskuList(shop_id);
            return Json(data);
        }

        /// <summary>
        /// 根据商品SKUId查询商品价钱
        /// </summary>
        /// <param name="shopsku_id">原始购买的商品Id</param>
        /// <param name="shopsku_id">重新选择后的商品Id</param>
        /// <returns></returns>
        [HttpGet("ShopMoneyBySkuId")]
        public async Task<IActionResult> ShopMoneyBySkuId(string shopsku_id, string check_shopsku_id)
        {
            var data = await orderService.ShopMoneyBySkuId(shopsku_id, check_shopsku_id);
            return Json(data);
        }

        /// 设置支付状态
        /// </summary>
        /// <param name="order_id">订单id</param>
        /// <param name="paystatus">支付状态(1:未支付，2：已支付)</param>
        /// <returns></returns>
        [HttpPut("Pay")]
        public async Task<IActionResult> Pay(string order_id, int payway)
        {
            var data = await orderService.Pay(order_id, payway, applicationConfigServices.MailConfigurations);
            return Json(data);
        }

        /// <summary>
        /// 升级系统方法实现
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="check_shopsku_id">选择的商品SKUId</param>
        /// <param name="shopsku_id">原始的商品SKUId</param>
        /// <returns></returns>
        [HttpPost("UpgradeOrder")]
        public async Task<IActionResult> UpgradeOrder(string order_id, string check_shopsku_id, string shopsku_id)
        {
            var data = await orderService.UpgradeOrder(order_id, check_shopsku_id, shopsku_id, applicationConfigServices.MailConfigurations);
            return Json(data);
        }

        /// 订单禁用
        /// </summary>
        /// <param name="order_id">订单id</param>
        /// <param name="disable_desc">禁用描述</param>
        /// <param name="type">启用禁用类型(1:禁用,0:启用)</param>
        /// <returns></returns>
        [HttpPut("Disable")]
        public async Task<IActionResult> Disable(string order_id, string disable_desc, int type)
        {
            var data = await orderService.Disable(order_id, disable_desc, type);
            return Json(data);
        }

        /// <summary>
        /// 订单删除
        /// </summary>
        /// <param name="order_id">订单id</param>
        /// <returns></returns>
        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(string order_id)
        {
            var data = await orderService.Delete(order_id);
            return Json(data);
        }

        /// <summary>
        /// 收入金额(已支付的订单统计)
        /// </summary>
        /// <returns></returns>
        [HttpGet("IncomeMoney")]
        public async Task<IActionResult> IncomeMoney()
        {
            var data = await orderService.IncomeMoney();
            return Json(data);
        }
    }
}