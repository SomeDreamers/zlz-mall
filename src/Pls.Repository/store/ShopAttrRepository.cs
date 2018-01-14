//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   DESKTOP-523FA9U
//  命名空间名称/文件名:        Pls.Repository/ShopAttrRepository 
//  创建人:                     kencery     
//  创建时间:                   2016/11/16 23:15:05
//  网站:                       http://www.chuxinm.com
//==============================================================

using Pls.Entity;
using Pls.IRepository;

namespace Pls.Repository
{
    /// <summary>
    /// 商品属性管理操作类实现
    /// </summary>
    public class ShopAttrRepository : BaseRepository<ShopAttrEntity>, IShopAttrRepository
    {
        public ShopAttrRepository(DataContext context) : base(context)
        {
        }
    }
}