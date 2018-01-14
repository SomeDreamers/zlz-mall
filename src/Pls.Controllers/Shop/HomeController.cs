//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.Controllers/HomeController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/22 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pls.Controllers
{
    /// <summary>
    /// 前台商品管理控制器
    /// </summary>
    public class HomeController : BaseController
    {
        //注入
        protected IShopService shopService { get; private set; }
        protected IOrderService orderService { get; private set; }
        protected ICommentService commentService { get; private set; }
        protected IUserService userService { get; private set; }
        public HomeController(ApplicationConfigServices _applicationConfigServices, IShopService _shopService, IOrderService _orderService,
            ICommentService _commentService, IUserService _userService)
            : base(_applicationConfigServices)
        {
            shopService = _shopService;
            orderService = _orderService;
            commentService = _commentService;
            userService = _userService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //读取首页需要显示的信息
            ViewBag.HomeDescription = applicationConfigServices.AppConfigurations.HomeDescription;
            ViewBag.HomeDescriptionStatus = applicationConfigServices.AppConfigurations.HomeDescriptionStatus;
            var data = await userService.GetTeamUserInfo();
            return View(data);
        }

        /// <summary>
        /// 详情页面的展示，在这里根据传递过来的商品Id查询到商品的所有信息，组装成实体返回
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var data = await shopService.GetShopDetailInfo(id);
            return View(data);
        }

        /// <summary>
        /// 根据商品Id和商品Sku_id查询商品SKU信息和商品图片信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shopsku_id">商品SKU_Id</param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpGet]
        public async Task<IActionResult> GetShopskuImage(string shop_id, string shopsku_id)
        {
            var data = await shopService.GetShopskuImage(shop_id, shopsku_id);
            return Json(data);
        }

        /// <summary>
        /// 查询商品评论信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="type">评论级别</param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpGet]
        public async Task<IActionResult> GetShopCommentInfo(string shop_id, int type)
        {
            var data = await commentService.GetShopCommentInfo(shop_id, type);
            return JsonDate(data);
        }

        /// <summary>
        /// 购物车页面的实现
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Cart()
        {
            //1标示用户没有登录，2标示用户已经登录
            var userSession = GetUserSessionFront();
            ViewBag.userType = userSession == null ? 1 : 2;
            return View();
        }

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="data">订单实体</param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        [Auth]
        public async Task<IActionResult> AddOrder(List<CartOrders> orders)
        {
            var data = await orderService.AddOrder(orders, return_front_userid());
            return Json(data);
        }

        /// <summary>
        /// 订单支付页面-根据订单Id查询出商品的信息
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <returns></returns>
        [HttpGet]
        [Auth]
        public async Task<IActionResult> Pay(string id)
        {
            var data = await orderService.getOrderPay(id, return_front_userid());
            return View(data);
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="order_memo">订单备注</param>
        /// <param name="isprivilege">是否优惠</param>
        /// <returns></returns>
        [Auth]
        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> PayOrder(string order_id, string order_memo, bool isprivilege)
        {
            var data = await orderService.PayOrder(order_id, order_memo, isprivilege);
            return Json(data);
        }

        /// <summary>
        /// 支付成功之后的跳转页面
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="money">实际支付金额</param>
        /// <returns></returns>
        [HttpGet]
        [Auth]
        public IActionResult PaySuccess(string order_id, string order_number, double money)
        {
            ViewBag.order_id = order_id;
            ViewBag.order_number = order_number;
            ViewBag.money = money;
            return View();
        }
    }
}