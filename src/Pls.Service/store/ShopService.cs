//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Service/ShopService 
//  创建人:                     kencery     
//  创建时间:                   2016/11/16 23:24:28
//  网站:                       http://www.chuxinm.com
//==============================================================

using System;
using System.Linq;
using Pls.Entity;
using Pls.IService;
using System.Linq.Expressions;
using Pls.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Pls.UnitOfWork;
using Pls.IRepository;
using Pls.Utils.oss;

namespace Pls.Service
{
    /// <summary>
    /// 商品管理业务实现
    /// </summary>
    public class ShopService : IShopService
    {
        //注入
        private IHostingEnvironment hostingEnv { get; set; }
        private IShopRepository shopRepository { get; set; }
        private IShopSkuRepository shopSkuRepository { get; set; }
        private IShopAttrRepository shopAttrRepository { get; set; }
        private IShopImageRepository shopImageRepository { get; set; }
        private IShopCouponRepository shopCouponRepository { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        public ShopService(IHostingEnvironment _hostingEnv, IShopRepository _shopRepository, IShopSkuRepository _shopSkuRepository,
            IShopAttrRepository _shopAttrRepository, IShopImageRepository _shopImageRepository, IShopCouponRepository _shopCouponRepository,
            IUnitOfWork _unitOfWork)
        {
            this.hostingEnv = _hostingEnv;
            this.shopRepository = _shopRepository;
            this.shopSkuRepository = _shopSkuRepository;
            this.shopAttrRepository = _shopAttrRepository;
            this.shopImageRepository = _shopImageRepository;
            this.shopCouponRepository = _shopCouponRepository;
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Pager<IQueryable<ShopEntity>>> List(ShopInfo shopInfo)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<ShopEntity, bool>> where_search = LinqUtil.True<ShopEntity>();
            if (!string.IsNullOrEmpty(shopInfo.shop_name))
            {
                where_search = where_search.AndAlso(c => c.shop_name.Contains(shopInfo.shop_name));
            }

            if (!string.IsNullOrEmpty(shopInfo.shop_number))
            {
                where_search = where_search.AndAlso(c => c.shop_number.Contains(shopInfo.shop_number));
            }

            if (shopInfo.shop_isdiscount != -1)
            {
                where_search = where_search.AndAlso(c => c.shop_isdiscount == (shopInfo.shop_isdiscount == 0) ? true : false);
            }

            if (shopInfo.disable != -1)
            {
                where_search = where_search.AndAlso(c => c.disable == shopInfo.disable);
            }

            //调用仓储方法查询分页并且处理之后响应前台
            //调用仓储方法查询分页并且响应给前台
            int total = await shopRepository.CountAsync(where_search);
            IQueryable<ShopEntity> shopEntitys = await shopRepository.GetPageAllAsync(shopInfo.pageindex, shopInfo.pagesize, where_search, c => c.createtime, (c => new ShopEntity()
            {
                shop_id = c.shop_id,
                shop_name = c.shop_name,
                shop_memo = c.shop_memo,
                shop_number = c.shop_number,
                shop_defaultimg = c.shop_defaultimg,
                shop_isdiscount = c.shop_isdiscount,
                createtime = c.createtime,
                disable = c.disable
            }), false);

            return new Pager<IQueryable<ShopEntity>>(total, shopEntitys);
        }

        public async Task<BaseResult<ShopEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<ShopEntity>(808);
            }

            var shopEntity = await shopRepository.GetAsync(c => c.shop_id.Equals(id));
            if (shopEntity == null)
            {
                return new BaseResult<ShopEntity>(202);
            }
            return new BaseResult<ShopEntity>(200, shopEntity);
        }

        public async Task<BaseResult<IQueryable<DropDownList>>> GetShopSkuById(string shop_id)
        {
            IQueryable<ShopSkuEntity> data = await shopSkuRepository.GetAllAsync(c => c.shop_id.Equals(shop_id) && c.disable == 0);
            var result = from n in data
                         select new DropDownList
                         {
                             value = n.shopsku_id,
                             name = n.shop_code
                         };
            return new BaseResult<IQueryable<DropDownList>>(200, result);
        }

        public async Task<BaseResult<IQueryable<ShopSkuEntity>>> GetShopSkuList(string shop_id)
        {
            IQueryable<ShopSkuEntity> data = await shopSkuRepository.GetAllAsync(c => c.shop_id.Equals(shop_id));
            return new BaseResult<IQueryable<ShopSkuEntity>>(200, data);
        }

        public async Task<BaseResult<ShopAttrEntity>> GetShopAttr(string shop_id)
        {
            if (string.IsNullOrEmpty(shop_id))
            {
                return new BaseResult<ShopAttrEntity>(808);
            }

            var shopEntity = await shopAttrRepository.GetAsync(c => c.shop_id.Equals(shop_id));
            if (shopEntity == null)
            {
                return new BaseResult<ShopAttrEntity>(202);
            }
            return new BaseResult<ShopAttrEntity>(200, shopEntity);
        }

        public async Task<BaseResult<IQueryable<ShopSkuImage>>> GetShopImageById(string shop_id)
        {
            if (string.IsNullOrEmpty(shop_id))
            {
                return new BaseResult<IQueryable<ShopSkuImage>>(808);
            }

            //根据商品Id查询未禁用的商品图片返回，join
            IQueryable<ShopSkuImage> query = from c in await shopSkuRepository.GetAllAsync(c => c.disable == 0 && c.shop_id == shop_id)
                                             join o in await shopImageRepository.GetAllAsync(c => c.disable == 0 && c.shop_id == shop_id)
                                             on c.shopsku_id equals o.shopsku_id
                                             select new ShopSkuImage()
                                             {
                                                 shopsku_name = c.shop_code,
                                                 shopimage_default = o.shopimage_default,
                                                 shopimage_address = o.shopimage_address,
                                                 shopsku_id = o.shopsku_id,
                                                 shopimage_id = o.shopimage_id,
                                                 shop_id = o.shop_id
                                             };
            return new BaseResult<IQueryable<ShopSkuImage>>(200, query);
        }

        public async Task<BaseResult<ShopCouponEntity>> GetShopCouponById(string shop_id)
        {
            if (string.IsNullOrEmpty(shop_id))
            {
                return new BaseResult<ShopCouponEntity>(808);
            }
            //业务，根据商品Id查询商品优惠，首先判断优惠的时间(当前时间>数据库设计的时间)是否已经结束，如果结束则直接修改优惠的状态为已结束状态
            var shopCouponEntity = await shopCouponRepository.GetAsync(c => c.shop_id.Equals(shop_id));
            if (shopCouponEntity == null)
            {
                return new BaseResult<ShopCouponEntity>(202);
            }

            if (DateTime.Now > shopCouponEntity.endtime)
            {
                var isShopCoupon = await shopCouponRepository.UpdateAsync(new ShopCouponEntity() { shopcoupon_id = shopCouponEntity.shopcoupon_id, disable = 1 }, true, true, c => c.disable);
                var isShop = await shopRepository.UpdateAsync(new ShopEntity() { shop_id = shop_id, shop_isdiscount = false }, true, true, c => c.shop_isdiscount);
                shopCouponEntity.disable = 1;
            }
            return new BaseResult<ShopCouponEntity>(200, shopCouponEntity);
        }

        public async Task<ShopClassifyInfo> GetShopHomeInfo(int top, int type)
        {
            var result = await shopRepository.GetShopHomeInfo(top, type);

            ShopClassifyInfo shopClassifyInfo = new ShopClassifyInfo
            {
                page_type = type == 4 ? 1 : 0,
                shopHomeInfos = result
            };
            return shopClassifyInfo;
        }

        public async Task<ShopDetailInfo> GetShopDetailInfo(string id)
        {
            //处理商品查询详情页的实现
            //第一步：首先根据商品Id查询商品详情信息
            var shopEntity = (from n in await shopRepository.GetAllAsync(c => c.shop_id == id && c.disable == 0)
                              select new ShopEntity()
                              {
                                  shop_id = n.shop_id,
                                  shop_name = n.shop_name,
                                  shop_memo = n.shop_memo,
                                  shop_number = n.shop_number,
                                  shop_desc = n.shop_desc,
                                  shop_defaultimg = n.shop_defaultimg
                              }).FirstOrDefault();

            //第二步：根据商品Id查询商品SKU Id的信息，返回集合
            var shopSkuEntitys = (from n in await shopSkuRepository.GetAllAsync(c => c.shop_id == id && c.disable == 0)
                                  select new ShopSkuEntity()
                                  {
                                      shopsku_id = n.shopsku_id,
                                      shop_code = n.shop_code,
                                      shopsku_currentprice = n.shopsku_currentprice,
                                      shopsku_originalprice = n.shopsku_originalprice,
                                      createtime = n.createtime
                                  }).OrderBy(c => c.createtime);

            //第三步：根据商品Id查询商品属性
            var shopAttrEntity = await shopAttrRepository.GetAsync(c => c.shop_id == id);

            //第四步：根据商品Id和商品SKU-Id查询图片信息(读取第一个版本的图片)
            IQueryable<ShopImageEntity> shopImageEntitys = null;
            if (shopSkuEntitys.FirstOrDefault() != null)
            {
                string shopsku_id = shopSkuEntitys.FirstOrDefault().shopsku_id;
                shopImageEntitys = (from n in await shopImageRepository.GetAllAsync(c => c.shop_id == id && c.shopsku_id == shopsku_id && c.disable == 0)
                                    select new ShopImageEntity()
                                    {
                                        shopimage_address = n.shopimage_address
                                    });
            }

            //第五步：根据商品Id查询商品优惠信息
            var datetime = DateTime.Now;
            var shopCouponEntity = (from n in await shopCouponRepository.GetAllAsync(c => c.shop_id == id && c.disable == 0 && c.endtime > DateTime.Now)
                                    select new ShopCouponEntity()
                                    {
                                        shopcoupon_type = n.shopcoupon_type,
                                        shopcoupon_name = n.shopcoupon_name,
                                        shopcoupon_money = n.shopcoupon_money
                                    }).FirstOrDefault();

            ShopDetailInfo shopDetailsInfo = new ShopDetailInfo
            {
                shopEntity = shopEntity,
                ShopSkuEntitys = shopSkuEntitys,
                shopSkuEntity = null,
                shopAttrEntity = shopAttrEntity,
                shopImageEntitys = shopImageEntitys,
                shopCouponEntity = shopCouponEntity
            };
            return shopDetailsInfo;
        }

        public async Task<BaseResult<ShopDetailInfo>> GetShopskuImage(string shop_id, string shopsku_id)
        {
            //根据商品Id和商品SkuId读取商品SKU信息、商品图片信息
            var shopSkuEntity = (from n in await shopSkuRepository.GetAllAsync(c => c.shop_id == shop_id && c.shopsku_id == shopsku_id && c.disable == 0)
                                 select new ShopSkuEntity()
                                 {
                                     shopsku_id = n.shopsku_id,
                                     shop_code = n.shop_code,
                                     shopsku_currentprice = n.shopsku_currentprice,
                                     shopsku_originalprice = n.shopsku_originalprice
                                 }).FirstOrDefault();
            var shopImageEntitys = (from n in await shopImageRepository.GetAllAsync(c => c.shop_id == shop_id && c.shopsku_id == shopsku_id && c.disable == 0)
                                    select new ShopImageEntity()
                                    {
                                        shopimage_address = n.shopimage_address
                                    });

            ShopDetailInfo shopDetailsInfo = new ShopDetailInfo
            {
                shopEntity = null,
                ShopSkuEntitys = null,
                shopSkuEntity = shopSkuEntity,
                shopAttrEntity = null,
                shopImageEntitys = shopImageEntitys,
                shopCouponEntity = null
            };
            return new BaseResult<ShopDetailInfo>(200, shopDetailsInfo);
        }

        public BaseResult<string> UploadEditor(IFormFileCollection files)
        {
            int result_number = 0;
            //var return_result = FileUtil.UploadQiniuImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, Settings.ShopImagePrefix, out result_number);
            //阿里云
            var return_result = OssOptionUtil.UploadAliYunImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, out result_number);
            if (string.IsNullOrEmpty(return_result))
            {
                return new BaseResult<string>(result_number);
            }
            return new BaseResult<string>(return_result);
        }

        public async Task<BaseResult<string>> Add(ShopEntity entity, string user_id)
        {
            //商品添加，名称可重复，含有商品编号区分
            if (string.IsNullOrEmpty(entity.shop_name))
            {
                return new BaseResult<string>(808, "");
            }
            entity.user_id = user_id;

            var isTrue = await shopRepository.AddAsync(entity);
            if (!isTrue)
            {
                return new BaseResult<string>(201, "");
            }
            return new BaseResult<string>(200, entity.shop_id);
        }

        public async Task<BaseResult<bool>> UpdateShop(ShopEntity entity)
        {
            //判断必须传递参数
            if (string.IsNullOrEmpty(entity.shop_name))
            {
                return new BaseResult<bool>(808, false);
            }

            var isTrue = await shopRepository.UpdateAsync(entity, true, true, c => c.shop_name, c => c.shop_memo, c => c.shop_desc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<string>> AddShopSku(ShopSkuEntity entity)
        {
            //商品添加，名称可重复，含有商品编号区分
            if (string.IsNullOrEmpty(entity.shop_id) || string.IsNullOrEmpty(entity.shopsku_code))
            {
                return new BaseResult<string>(808, "");
            }
            if (Convert.ToDouble(entity.shopsku_currentprice) > Convert.ToDouble(entity.shopsku_originalprice))
            {
                return new BaseResult<string>(3005, "");
            }

            var isTrue = await shopSkuRepository.AddAsync(entity);
            if (!isTrue)
            {
                return new BaseResult<string>(201, "");
            }
            return new BaseResult<string>(200, entity.shopsku_id);
        }

        public async Task<BaseResult<bool>> DeleteShopSku(string shop_id, string shosku_id)
        {
            if (string.IsNullOrEmpty(shop_id) || string.IsNullOrEmpty(shosku_id))
            {
                return new BaseResult<bool>(808, false);
            }

            var isTrue = await shopSkuRepository.DeleteAsync(c => c.shop_id.Equals(shop_id) && c.shopsku_id.Equals(shosku_id));
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> DisableShopSku(string shopsku_id, string disable_status)
        {
            if (string.IsNullOrEmpty(shopsku_id))
            {
                return new BaseResult<bool>(808, false);
            }

            var isTrue = await shopSkuRepository.UpdateAsync(new ShopSkuEntity { shopsku_id = shopsku_id, disable = Convert.ToInt32(disable_status) }, true, true, c => c.disable);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> UpdateShopSku(ShopSkuEntity entity)
        {
            //判断必须传递参数
            if (string.IsNullOrEmpty(entity.shopsku_id))
            {
                return new BaseResult<bool>(808, false);
            }
            if (Convert.ToDouble(entity.shopsku_currentprice) > Convert.ToDouble(entity.shopsku_originalprice))
            {
                return new BaseResult<bool>(3005, false);
            }

            var isTrue = await shopSkuRepository.UpdateAsync(entity, true, true, c => c.shop_code, c => c.shopsku_originalprice, c => c.shopsku_currentprice, c => c.shopsku_url, c => c.shopsku_code);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> AddShopAttr(ShopAttrEntity entity)
        {
            var count = shopAttrRepository.Count(c => c.shop_id.Equals(entity.shop_id));
            if (count >= 1)
            {
                return new BaseResult<bool>(3002, false);
            }
            var isTrue = await shopAttrRepository.AddAsync(entity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> UpdateShopAttr(ShopAttrEntity entity)
        {
            //检查数据库中是否含有数据，如果含有，则修改，否则直接添加
            var count = await shopAttrRepository.CountAsync(c => c.shop_id == entity.shop_id);
            var isTrue = false;
            if (count > 0)
            {
                isTrue = await shopAttrRepository.UpdateAsync(entity, true, false, c => c.shop_id);
            }
            else
            {
                isTrue = await shopAttrRepository.AddAsync(entity);
            }
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public BaseResult<DropDownList> UploadShopImage(IFormFileCollection files, string shop_id, string shopsku_id)
        {
            //首先上传图片读取到上传的图片的路径,然后根据传递过来的参数进行添加数据库，添加完成之后返回信息
            if (string.IsNullOrEmpty(shop_id) || string.IsNullOrEmpty(shopsku_id))
            {
                return new BaseResult<DropDownList>(808, null);
            }

            //插入之前判断这个模板下面的图片未禁用的数量是否已经是4个了，如果是4个，则不允许添加
            var count = shopImageRepository.Count(c => c.shop_id.Equals(shop_id) && c.shopsku_id.Equals(shopsku_id) && c.disable == 0);
            if (count >= 4)
            {
                return new BaseResult<DropDownList>(3004, null);
            }

            int result_number = 0;
            //var return_result = FileUtil.UploadQiniuImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, Settings.ShopImagePrefix, out result_number);
            //阿里云
            var return_result = OssOptionUtil.UploadAliYunImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, out result_number);
            if (string.IsNullOrEmpty(return_result))
            {
                return new BaseResult<DropDownList>(result_number, null);
            }

            ShopImageEntity shopImageEntity = new ShopImageEntity
            {
                shop_id = shop_id,
                shopsku_id = shopsku_id,
                shopimage_address = return_result,
                shopimage_default = false
            };
            var isTrue = shopImageRepository.Add(shopImageEntity);
            if (!isTrue)
            {
                return new BaseResult<DropDownList>(201, null);
            }
            return new BaseResult<DropDownList>(200, new DropDownList
            {
                name = shopsku_id + "," + shopImageEntity.shopimage_id,
                value = return_result
            });
        }

        public async Task<BaseResult<bool>> DeleteShopImage(string shopimage_id)
        {
            if (string.IsNullOrEmpty(shopimage_id))
            {
                return new BaseResult<bool>(808, false);
            }

            var isTrue = await shopImageRepository.UpdateAsync(new ShopImageEntity { shopimage_id = shopimage_id, disable = 1 }, true, true, c => c.disable);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<DropDownList>> DefaultShopImage(string shop_id, string shopimage_id)
        {

            //第一步：根据商品ip将所有的图片默认状态置为否
            var isDefaultNo = await shopImageRepository.UpdateDefaultByShopId(shop_id);

            //将当前图片的内容设置我默认
            var isDefaultYes = await shopImageRepository.UpdateAsync(new ShopImageEntity() { shopimage_id = shopimage_id, shopimage_default = true }, false, true, c => c.shopimage_default);

            //根据当前的图片内容图片路径并且修改主表信息
            var shopImage = await shopImageRepository.GetAsync(c => c.shopimage_id.Equals(shopimage_id));

            var isTrue = await shopRepository.UpdateAsync(new ShopEntity { shop_id = shop_id, shop_defaultimg = shopImage.shopimage_address }, false, true, c => c.shop_defaultimg);

            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<DropDownList>(200, new DropDownList() { name = shopimage_id, value = shopImage.shopimage_address });
            }
            return new BaseResult<DropDownList>(201, null);
        }

        public async Task<BaseResult<bool>> AddShopCoupon(ShopCouponEntity entity)
        {
            //1.判断优惠只能包含1个，2.判断优惠金额必须低于商品SKU的最低金额,2.同步添加商品优惠表和修改商品表的优惠状态3.
            var count = shopCouponRepository.Count(c => c.shop_id.Equals(entity.shop_id));
            if (count >= 1)
            {
                return new BaseResult<bool>(3003, false);
            }
            string minShopSkuMoney = (from n in await shopSkuRepository.GetAllAsync(c => c.shop_id.Equals(entity.shop_id))
                                      select n.shopsku_currentprice).Min();
            if (string.IsNullOrEmpty(minShopSkuMoney))
            {
                return new BaseResult<bool>(3006, false);
            }
            if (Convert.ToDouble(minShopSkuMoney) < entity.shopcoupon_money)
            {
                return new BaseResult<bool>(3007, false);
            }

            var isTrue = await shopCouponRepository.AddAsync(entity, false);
            var isUpdate = await shopRepository.UpdateAsync(new ShopEntity { shop_id = entity.shop_id, shop_isdiscount = true }, false, true, c => c.shop_isdiscount);
            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> UpdateShopCoupon(ShopCouponEntity entity)
        {
            string minShopSkuMoney = (from n in await shopSkuRepository.GetAllAsync(c => c.shop_id.Equals(entity.shop_id))
                                      select n.shopsku_currentprice).Min();
            if (string.IsNullOrEmpty(minShopSkuMoney))
            {
                return new BaseResult<bool>(3006, false);
            }
            if (Convert.ToDouble(minShopSkuMoney) < entity.shopcoupon_money)
            {
                return new BaseResult<bool>(3007, false);
            }

            var isTrue = await shopCouponRepository.UpdateAsync(entity, false, true, c => c.shopcoupon_type, c => c.shopcoupon_name, c => c.shopcoupon_money, c => c.endtime, c => c.disable);
            if (entity.disable == 1)
            {
                var isUpdate = await shopRepository.UpdateAsync(new ShopEntity { shop_id = entity.shop_id, shop_isdiscount = false }, false, true, c => c.shop_isdiscount);
            }
            else
            {
                var isUpdate = await shopRepository.UpdateAsync(new ShopEntity { shop_id = entity.shop_id, shop_isdiscount = true }, false, true, c => c.shop_isdiscount);
            }
            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> DeleteShopCoupon(string shopcoupon_id, string shop_id)
        {
            var isTrue = await shopCouponRepository.DeleteAsync(c => c.shopcoupon_id.Equals(shopcoupon_id), false);
            var isUpdate = await shopRepository.UpdateAsync(new ShopEntity { shop_id = shop_id, shop_isdiscount = false }, false, true, c => c.shop_isdiscount);

            if (unitOfWork.SaveCommit())
            {
                return new BaseResult<bool>(200, true);
            }
            return new BaseResult<bool>(201, false);
        }

        public async Task<BaseResult<bool>> Disable(string shop_id, string disable_desc, int type)
        {
            if (string.IsNullOrEmpty(shop_id))
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            ShopEntity shopEntity = await shopRepository.GetAsync(c => c.shop_id.Equals(shop_id));
            if (string.IsNullOrEmpty(shopEntity.disabledesc))
            {
                str = "{'disable':'" + shopEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = shopEntity.disabledesc + ",{'disable':'" + shopEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }

            ShopEntity entity = new ShopEntity()
            {
                shop_id = shop_id,
                disabledesc = str,
                disable = type
            };
            var isTrue = await shopRepository.UpdateAsync(entity, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);


            throw new NotImplementedException();
        }

        public BaseResult<string> UploadEvaluateImage(IFormFileCollection files)
        {
            int result_number = 0;
            //var return_result = FileUtil.UploadQiniuImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, Settings.ShopImagePrefix, out result_number);
            //阿里云
            var return_result = OssOptionUtil.UploadAliYunImage(files, FileUtil.localhost_image, hostingEnv.WebRootPath, out result_number);
            if (string.IsNullOrEmpty(return_result))
            {
                return new BaseResult<string>(result_number);
            }
            return new BaseResult<string>(return_result);
        }
    }
}