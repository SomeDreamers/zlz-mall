//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.IService/ICarouselService 
//  创建人:                     Brian     
//  创建时间:                   12/04/2016 14:34:24 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IService
{
    /// <summary>
    ///  轮播图片管理业务接口
    /// </summary>
    public interface ICarouselService
    {
        /// <summary>
        /// 异步查询轮播列表
        /// </summary>
        /// <param name="carouselInfo">查询条件</param>
        /// <returns></returns>
        Task<Pager<IQueryable<CarouselEntity>>> List(CarouselInfo carouselInfo);

        /// <summary>
        /// 根据主键Id查询轮播信息
        /// </summary>
        /// <param name="id">查询条件</param>
        /// <returns></returns>
        Task<BaseResult<CarouselEntity>> GetById(string id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="carouselEntity">条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Add(CarouselEntity carouselEntity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="carouselEntity">条件</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Update(CarouselEntity carouselEntity);

        /// <summary>
        /// 启用/禁用
        /// </summary>
        /// <param name="carousel_id">Id</param>
        /// <param name="disable_desc">描述</param>
        /// <param name="type">启用禁用类型</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Disable(string carousel_id, string disable_desc, int type);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<BaseResult<bool>> Delete(string id);
    }
}
