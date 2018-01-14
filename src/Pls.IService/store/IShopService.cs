//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.IService/IShopService 
//  创建人:                     kencery     
//  创建时间:                   2016/11/16 23:23:05
//  网站:                       http://www.chuxinm.com
//==============================================================
using Microsoft.AspNetCore.Http;
using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    /// 商品管理业务接口
    /// </summary>
    public interface IShopService
    {
        /// <summary>
        /// 根据查询条件异步查询商品信息
        /// </summary>
        /// <param name="shopEntity">查询实体</param>
        /// <returns></returns>
        Task<Pager<IQueryable<ShopEntity>>> List(ShopInfo shopInfo);

        /// <summary>
        /// 根据商品Id查询商品详细信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<ShopEntity>> GetById(string id);

        /// <summary>
        /// 根据商品Id查询商品SKU
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<DropDownList>>> GetShopSkuById(string shop_id);

        /// <summary>
        /// 根据商品Id查询商品Sku信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<ShopSkuEntity>>> GetShopSkuList(string shop_id);

        /// <summary>
        /// 根据商品Id查询商品属性信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<ShopAttrEntity>> GetShopAttr(string shop_id);

        /// <summary>
        /// 根据商品Id查询商品图片信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<ShopSkuImage>>> GetShopImageById(string shop_id);

        /// <summary>
        /// 根据商品Id查询商品优惠信息
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<ShopCouponEntity>> GetShopCouponById(string shop_id);

        /// <summary>
        /// 查询首页商品信息
        /// </summary>
        /// <param name="top">显示几条数据</param>
        /// <param name="type">分类描述(1:发展历程,2:最新推荐,3:初心优惠)</param>
        /// <returns></returns>
        Task<ShopClassifyInfo> GetShopHomeInfo(int top, int type);

        /// <summary>
        /// 详情页面的展示，在这里根据传递过来的商品Id查询到商品的所有信息，组装成实体返回
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <returns></returns>
        Task<ShopDetailInfo> GetShopDetailInfo(string id);

        /// <summary>
        /// 根据商品Id和商品Sku_id查询商品SKU信息和商品图片细腻
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shopsku_id">商品SKU_Id</param>
        /// <returns></returns>
        Task<BaseResult<ShopDetailInfo>> GetShopskuImage(string shop_id, string shopsku_id);

        /// <summary>
        /// 商品管理富文本编辑器上传图片
        /// </summary>
        /// <returns></returns>
        BaseResult<string> UploadEditor(IFormFileCollection files);

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="user_id">用户Id</param>
        /// <returns></returns>
        Task<BaseResult<string>> Add(ShopEntity entity, string user_id);

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateShop(ShopEntity entity);

        /// <summary>
        /// 添加商品SKU
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        Task<BaseResult<string>> AddShopSku(ShopSkuEntity entity);

        /// <summary>
        /// 删除商品SKU
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shosku_id">商品SKU_Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> DeleteShopSku(string shop_id, string shosku_id);

        /// <summary>
        /// 启用禁用商品SKU
        /// </summary>
        /// <param name="shopsku_id">商品skuid</param>
        /// <param name="disable_status">启用禁用状态</param>
        /// <returns></returns>
        Task<BaseResult<bool>> DisableShopSku(string shopsku_id, string disable_status);

        /// <summary>
        /// 商品SKU修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateShopSku(ShopSkuEntity entity);

        /// <summary>
        /// 添加商品属性
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddShopAttr(ShopAttrEntity entity);

        /// <summary>
        /// 修改商品属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateShopAttr(ShopAttrEntity entity);

        /// <summary>
        /// 商品图片上传并且写入数据库
        /// </summary>
        /// <param name="files">上传的文件</param>
        /// <param name="shop_id">商品Id</param>
        /// <param name="shopsku_id">商品SKU Id</param>
        /// <returns></returns>
        BaseResult<DropDownList> UploadShopImage(IFormFileCollection files, string shop_id, string shopsku_id);

        /// <summary>
        /// 删除商品图片
        /// </summary>
        /// <param name="shopimage_id">商品图片</param>
        /// <returns></returns>
        Task<BaseResult<bool>> DeleteShopImage(string shopimage_id);

        /// <summary>
        /// 设置默认商品图片
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="default_id">商品SKUId</param>
        /// <returns></returns>
        Task<BaseResult<DropDownList>> DefaultShopImage(string shop_id, string shopimage_id);

        /// <summary>
        /// 添加商品优惠信息
        /// </summary>
        /// <param name="entity">添加实体</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddShopCoupon(ShopCouponEntity entity);

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="entity">商品实体完成</param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateShopCoupon(ShopCouponEntity entity);

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="shopcoupon_id">商品优惠Id</param>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> DeleteShopCoupon(string shopcoupon_id, string shop_id);

        /// <summary>
        /// 启用禁用方法
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <param name="disable_desc">描述</param>
        /// <param name="type">类别</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string shop_id, string disable_desc, int type);

        /// <summary>
        /// 上传商品评论图片
        /// </summary>
        /// <param name="files">上传的文件</param>
        /// <returns></returns>
        BaseResult<string> UploadEvaluateImage(IFormFileCollection files);
    }
}