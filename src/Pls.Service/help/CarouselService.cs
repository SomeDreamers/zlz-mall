//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:        Pls.Service/MessageService 
//  创建人:                     Brian     
//  创建时间:                   12/04/2016 21:38:48 PM
//  网站:                       http://www.chuxinm.com
//==============================================================

using System;
using System.Linq;
using Pls.Entity;
using Pls.IService;
using System.Linq.Expressions;
using Pls.Utils;
using Pls.IRepository;
using System.Threading.Tasks;

namespace Pls.Service
{
    /// <summary>
    ///  轮播管理业务接口
    /// </summary>
    public class CarouselService : ICarouselService
    {
        //注入轮播管理操作
        private ICarouselRepository carouselRepository { get; set; }

        public CarouselService(ICarouselRepository _carouselRepository)
        {
            carouselRepository = _carouselRepository;
        }

        public async Task<Pager<IQueryable<CarouselEntity>>> List(CarouselInfo carouselInfo)
        {
            //判断查询参数（组装查询条件）
            Expression<Func<CarouselEntity, bool>> where_search = LinqUtil.True<CarouselEntity>();
            if (!string.IsNullOrEmpty(carouselInfo.carousel_titie))
            {
                where_search = where_search.AndAlso(c => c.carousel_titie.Contains(carouselInfo.carousel_titie));
            }

            if (carouselInfo.disable != -1)
            {
                where_search = where_search.AndAlso(c => c.disable == carouselInfo.disable);
            }

            //调用仓储方法查询分页并且响应给前台
            int total = await carouselRepository.CountAsync(where_search);
            IQueryable<CarouselEntity> carouselEntitys = await carouselRepository.GetPageAllAsync(carouselInfo.pageindex, carouselInfo.pagesize, where_search,
                c => c.createtime, (c => new CarouselEntity
                {
                    carousel_id = c.carousel_id,
                    carousel_titie = c.carousel_titie,
                    carousel_conent = c.carousel_conent,
                    carousel_image = c.carousel_image,
                    carousel_href = c.carousel_href,
                    carousel_sort = c.carousel_sort,
                    createtime = c.createtime,
                    disable = c.disable,
                    disabledesc = c.disabledesc
                }), false);

            return new Pager<IQueryable<CarouselEntity>>(total, carouselEntitys);
        }

        public async Task<BaseResult<CarouselEntity>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<CarouselEntity>(808);
            }

            var shopEntity = await carouselRepository.GetAsync(c => c.carousel_id.Equals(id));
            if (shopEntity == null)
            {
                return new BaseResult<CarouselEntity>(202);
            }
            return new BaseResult<CarouselEntity>(200, shopEntity);
        }

        public Task<BaseResult<bool>> Add(CarouselEntity carouselEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<bool>> Update(CarouselEntity carouselEntity)
        {
            //判断必须传递参数
            if (string.IsNullOrEmpty(carouselEntity.carousel_titie))
            {
                return new BaseResult<bool>(808, false);
            }

            var isTrue = await carouselRepository.UpdateAsync(carouselEntity, true, true,
                c => c.carousel_image,
                c => c.carousel_titie, c => c.carousel_conent,
                c => c.carousel_href, c => c.carousel_sort);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Disable(string carousel_id, string disable_desc, int type)
        {
            if (carousel_id.Length <= 0)
            {
                return new BaseResult<bool>(808);
            }

            //首先查询数据读取原始的desc
            var str = "";
            var carouselEntity = await carouselRepository.GetAsync(c => c.carousel_id.Equals(carousel_id));
            if (string.IsNullOrEmpty(carouselEntity.disabledesc))
            {
                str = "{'disable':'" + carouselEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            else
            {
                str = carouselEntity.disabledesc + ",{'disable':'" + carouselEntity.disable + "','disable_desc':'" + disable_desc + "'}";
            }
            CarouselEntity vmodel = new CarouselEntity()
            {
                carousel_id = carousel_id,
                disabledesc = str,
                disable = type
            };

            var isTrue = await carouselRepository.UpdateAsync(vmodel, true, true, c => c.disable, c => c.disabledesc);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

        public async Task<BaseResult<bool>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BaseResult<bool>(808);
            }

            CarouselEntity carouselEntity = new CarouselEntity()
            {
                carousel_id = id
            };
            var isTrue = await carouselRepository.DeleteAsync(carouselEntity);
            if (!isTrue)
            {
                return new BaseResult<bool>(201, false);
            }
            return new BaseResult<bool>(200, true);
        }

    }
}
