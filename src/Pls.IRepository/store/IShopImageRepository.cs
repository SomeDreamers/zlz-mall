//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.IRepository/IShopImageRepository 
//  创建人:                     kencery     
//  创建时间:                   2016/11/16 22:40:37
//  网站:                       http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 商品图片管理操作类接口
    /// </summary>
    public interface IShopImageRepository : IBaseRepository<ShopImageEntity>
    {
        /// <summary>
        /// 根据商品Id修改商品图片默认状态全部为不默认
        /// </summary>
        /// <param name="shop_id">商品Id</param>
        /// <returns></returns>
        Task<int> UpdateDefaultByShopId(string shop_id);

    }
}