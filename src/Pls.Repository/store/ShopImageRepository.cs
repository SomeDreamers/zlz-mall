//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Repository/ShopImageRepository 
//  创建人:                     kencery     
//  创建时间:                   2016/11/16 23:17:59
//  网站:                       http://www.chuxinm.com
//==============================================================

using Microsoft.EntityFrameworkCore;
using Pls.Entity;
using Pls.IRepository;
using System.Threading.Tasks;

namespace Pls.Repository
{
    /// <summary>
    /// 商品图片管理操作类实现
    /// </summary>
    public class ShopImageRepository : BaseRepository<ShopImageEntity>, IShopImageRepository
    {
        public ShopImageRepository(DataContext context) : base(context)
        {
        }

        public async Task<int> UpdateDefaultByShopId(string shop_id)
        {
            string sql = @"Update Pls_ShopImage set shopimage_default=false where shop_id={0}";

            return await Task.Run(() => ctx.Database.ExecuteSqlCommand(sql, shop_id));
        }
    }
}