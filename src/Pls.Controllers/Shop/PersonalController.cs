//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers/PersonalController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/1 19:32:24
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers
{
    /// <summary>
    /// 个人中心的配置信息
    /// </summary>
    [Auth]
    public class PersonalController : BaseController
    {
        protected IOrderService orderService { get; private set; }
        protected IShopService shopService { get; private set; }
        protected ICommentService commentService { get; private set; }
        public PersonalController(ApplicationConfigServices _applicationConfigServices, IOrderService _orderService, IShopService _shopService,
            ICommentService _commentService)
            : base(_applicationConfigServices)
        {
            orderService = _orderService;
            shopService = _shopService;
            commentService = _commentService;
        }

        /// <summary>
        /// 个人中心—订单中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //查询登录用户下 所有的订单信息返回给前端展示
            var data = await orderService.OrderListByUserId(return_front_userid(), 1);
            return View(data);
        }

        /// <summary>
        /// 订单详情实现
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OrderDetail(string order_id)
        {
            var data = await orderService.OrderListByUserId(return_front_userid(), 4, order_id);
            return View(data.rows);
        }

        /// <summary>
        /// 评价晒单和追加评价
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <param name="shopsku_id">商品SKU_Id</param>
        /// <returns></returns>
        public async Task<IActionResult> EvaluateIndex(string order_id, string shopsku_id)
        {
            var data = await orderService.OrderInfoByShopSkuId(return_front_userid(), order_id, shopsku_id);
            return View(data);
        }

        /// <summary>
        /// 根据用户和传递的类别Id查询该用户的订单信息
        /// </summary>
        /// <param name="type">类型(1:全部，2:待付款，3:待收货)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OrderListByUserId(int type)
        {
            var data = await orderService.OrderListByUserId(return_front_userid(), type);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 根据订单详情Id删除订单信息
        /// </summary>
        /// <param name="orderdetail_id">订单详情Id</param>
        /// <param name="order_id">订单Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteOrderDetail(string orderdetail_id, string order_id)
        {
            var data = await orderService.DeleteOrderDetail(orderdetail_id, order_id);
            return Json(data);
        }

        /// <summary>
        /// 根据订单Id对主表进行修改—确认收货订单
        /// </summary>
        /// <param name="order_id">订单Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateOkGoods(string order_id)
        {
            var data = await orderService.UpdateOkGoods(order_id);
            return Json(data);
        }

        /// <summary>
        /// 上传商品评论图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadEvaluateImage()
        {
            IFormFileCollection files = Request.Form.Files;
            var data = shopService.UploadEvaluateImage(files);
            return Json(data);
        }

        /// <summary>
        /// 为商品添加评论信息
        /// </summary>
        /// <param name="CommentShop">商品评论实体</param>
        /// <returns></returns>
        public async Task<IActionResult> AddComment(CommentShop CommentShop)
        {
            CommentShop.user_id = return_front_userid();
            var data = await commentService.AddComment(CommentShop);
            return Json(data);
        }
    }
}