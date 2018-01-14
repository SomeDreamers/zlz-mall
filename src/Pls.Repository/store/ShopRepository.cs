//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Repository/ShopRepository 
//  创建人:                     kencery     
//  创建时间:                   2016/11/16 23:03:33
//  网站:                       http://www.chuxinm.com
//==============================================================

using System.Linq;
using System.Threading.Tasks;
using Pls.Entity;
using Pls.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Pls.Repository
{
    /// <summary>
    /// 商品管理操作类实现
    /// </summary>
    public class ShopRepository : BaseRepository<ShopEntity>, IShopRepository
    {
        public ShopRepository(DataContext context) : base(context)
        {
        }

        public Task<IQueryable<ShopHomeInfo>> GetShopHomeInfo(int top, int type)
        {
            const string sql = @"SELECT shop.shop_id,shop.shop_name,shop.shop_defaultimg, shop.shop_isdiscount, shop.createtime,shopsku.shop_money,shoppay.shop_paycount  FROM Pls_Shop AS shop
		        INNER JOIN (SELECT shop_id, MIN(shopsku_currentprice) AS shop_money FROM  Pls_ShopSku GROUP BY shop_id) AS shopsku ON shop.shop_id=shopsku.shop_id
		        LEFT JOIN (SELECT shop_id,COUNT(1) AS shop_paycount FROM Pls_OrderDetail WHERE orderdetail_delete=1  GROUP BY shop_id)  AS shoppay ON shop.shop_id=shoppay.shop_id 
					WHERE shop.`disable`= 0 AND shop.shop_defaultimg IS NOT NULL";

            //查询结果
            IQueryable<ShopHomeInfo> shophomeInfo = ctx.shopHomeInfos.FromSql(sql);
            if (type == 2)
            {
                shophomeInfo = shophomeInfo.OrderByDescending(c => c.createtime);
            }
            else if (type == 3)
            {
                shophomeInfo = shophomeInfo.OrderBy(c => c.createtime);
            }
            else if (type == 4)
            {
                shophomeInfo = shophomeInfo.OrderByDescending(c => c.shop_paycount);
            }
            else
            {
                shophomeInfo = shophomeInfo.OrderByDescending(c => c.shop_isdiscount);
            }

            return Task.Run(() => shophomeInfo.Take(top));
        }
    }
}