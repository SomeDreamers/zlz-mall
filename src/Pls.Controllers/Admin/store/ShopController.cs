//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Controllers.Admin/VersionController 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016-11-15 20:59:32
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pls.Entity;
using Pls.IService;
using Pls.Utils;
using System.Threading.Tasks;

namespace Pls.Controllers.Admin
{
    /// <summary>
    /// 商品管理控制器的实现
    /// </summary>
    [Area("Admin")]
    [Route("Admin/Shop")]
    [Login]
    public class ShopController : BaseController
    {
        //注入
        public IShopService shopService;
        public ShopController(ApplicationConfigServices _applicationConfigServices, IShopService _shopService)
            : base(_applicationConfigServices)
        {
            shopService = _shopService;
        }

        /// <summary>
        /// 商品管理首页
        /// </summary>
        /// <returns></returns>
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据查询条件异步查询商品信息
        /// </summary>
        /// <param name="shopEntity">查询实体</param>
        /// <returns></returns>
        [HttpGet("List")]
        [AjaxOnly]
        public async Task<IActionResult> List(ShopInfo shopInfo)
        {
            var data = await shopService.List(shopInfo);
            return JsonDate(data);
        }

        /// <summary>
        /// 根据商品Id查询商品详细信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [AjaxOnly]
        public async Task<IActionResult> GetById(string shop_id)
        {
            var data = await shopService.GetById(shop_id);
            return JsonDateTime(data);
        }

        /// <summary>
        /// 根据商品Id查询商品SKU
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("GetShopSkuById")]
        [AjaxOnly]
        public async Task<IActionResult> GetShopSkuById(string shop_id)
        {
            var data = await shopService.GetShopSkuById(shop_id);
            return Json(data);
        }

        /// <summary>
        /// 根据商品Id查询商品Sku信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("GetShopSkuList")]
        [AjaxOnly]
        public async Task<IActionResult> GetShopSkuList(string shop_id)
        {
            var data = await shopService.GetShopSkuList(shop_id);
            return JsonDate(data);
        }

        /// <summary>
        /// 根据商品Id查询商品属性信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("GetShopAttr")]
        [AjaxOnly]
        public async Task<IActionResult> GetShopAttr(string shop_id)
        {
            var data = await shopService.GetShopAttr(shop_id);
            return Json(data);
        }

        /// <summary>
        /// 根据商品Id查询商品图片信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("GetShopImageById")]
        [AjaxOnly]
        public async Task<IActionResult> GetShopImageById(string shop_id)
        {
            var data = await shopService.GetShopImageById(shop_id);
            return Json(data);
        }

        /// <summary>
        /// 根据商品Id查询商品优惠信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpGet("GetShopCouponById")]
        [AjaxOnly]
        public async Task<IActionResult> GetShopCouponById(string shop_id)
        {
            var data = await shopService.GetShopCouponById(shop_id);
            return JsonDate(data);
        }

        /// <summary>
        /// 商品管理富文本编辑器上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost("UploadEditor")]
        public IActionResult UploadEditor()
        {
            IFormFileCollection files = Request.Form.Files;
            var data = shopService.UploadEditor(files);
            return Content(data.data);
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        [HttpPost("AddShop")]
        [AjaxOnly]
        public async Task<IActionResult> AddShop(ShopEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.Add(entity, GetUserSession().user_id);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPut("UpdateShop")]
        [AjaxOnly]
        public async Task<IActionResult> UpdateShop(ShopEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.UpdateShop(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 添加商品SKU
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        [HttpPost("AddShopSku")]
        [AjaxOnly]
        public async Task<IActionResult> AddShopSku(ShopSkuEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.AddShopSku(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 删除商品SKU
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shosku_id">商品SKU_Id</param>
        /// <returns></returns>
        [HttpDelete("DeleteShopSku")]
        [AjaxOnly]
        public async Task<IActionResult> DeleteShopSku(string shop_id, string shosku_id)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.DeleteShopSku(shop_id, shosku_id);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 启用禁用商品SKU
        /// </summary>
        /// <param name="shopsku_id">商品skuid</param>
        /// <param name="disable_status">启用禁用状态</param>
        /// <returns></returns>
        [HttpPut("DisableShopSku")]
        [AjaxOnly]
        public async Task<IActionResult> DisableShopSku(string shopsku_id, string disable_status)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.DisableShopSku(shopsku_id, disable_status);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 商品SKU修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPut("UpdateShopSku")]
        [AjaxOnly]
        public async Task<IActionResult> UpdateShopSku(ShopSkuEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.UpdateShopSku(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 添加商品属性
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        [HttpPost("AddShopAttr")]
        [AjaxOnly]
        public async Task<IActionResult> AddShopAttr(ShopAttrEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.AddShopAttr(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 修改商品属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPut("UpdateShopAttr")]
        [AjaxOnly]
        public async Task<IActionResult> UpdateShopAttr(ShopAttrEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.UpdateShopAttr(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 商品图片上传并且写入数据库
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shopsku_id">商品SKU Id</param>
        /// <returns></returns>
        [HttpPost("UploadShopImage")]
        public IActionResult UploadShopImage(string shop_id, string shopsku_id)
        {
            IFormFileCollection files = Request.Form.Files;
            var data = shopService.UploadShopImage(files, shop_id, shopsku_id);
            return Json(data);
        }

        /// <summary>
        /// 删除商品图片
        /// </summary>
        /// <param name="shopimage_id">商品图片</param>
        /// <returns></returns>
        [HttpPut("DeleteShopImage")]
        [AjaxOnly]
        public async Task<IActionResult> DeleteShopImage(string shopimage_id)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.DeleteShopImage(shopimage_id);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 设置默认商品图片
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shopimage_id">商品图片Id</param>
        /// <returns></returns>
        [HttpPut("DefaultShopImage")]
        [AjaxOnly]
        public async Task<IActionResult> DefaultShopImage(string shop_id, string shopimage_id)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.DefaultShopImage(shop_id, shopimage_id);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 添加商品优惠信息
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        [HttpPost("AddShopCoupon")]
        [AjaxOnly]
        public async Task<IActionResult> AddShopCoupon(ShopCouponEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.AddShopCoupon(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="entity">商品实体完成</param>
        /// <returns></returns>
        [HttpPut("UpdateShopCoupon")]
        [AjaxOnly]
        public async Task<IActionResult> UpdateShopCoupon(ShopCouponEntity entity)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.UpdateShopCoupon(entity);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="shopcoupon_id">商品优惠Id</param>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        [HttpDelete("DeleteShopCoupon")]
        [AjaxOnly]
        public async Task<IActionResult> DeleteShopCoupon(string shopcoupon_id, string shop_id)
        {
            if (ModelState.IsValid)
            {
                var data = await shopService.DeleteShopCoupon(shopcoupon_id, shop_id);
                return Json(data);
            }
            return Json(ParrNoPass());
        }

        /// <summary>
        /// 启用禁用方法
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="disable_desc">描述</param>
        /// <param name="type">类别</param>
        /// <returns></returns>
        [HttpPut("Disable")]
        [AjaxOnly]
        public async Task<IActionResult> Disable(string shop_id, string disable_desc, int type)
        {
            var data = await shopService.Disable(shop_id, disable_desc, type);
            return Json(data);
        }

    }
}