using Pls.Entity.entity.store;
using Pls.IRepository.store;
using System;
using System.Collections.Generic;
using System.Text;
using Pls.Entity;

namespace Pls.Repository.store
{
    /// <summary>
    /// 店铺商品仓储管理
    /// </summary>
    public class ShopCategoryRepository : BaseRepository<ShopCategoryEntity>, IShopCategoryRepository
    {
        public ShopCategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
