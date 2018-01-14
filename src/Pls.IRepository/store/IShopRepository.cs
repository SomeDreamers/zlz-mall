//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.IRepository/IShopRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016-11-16 17:38:50
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.IRepository
{
    /// <summary>
    /// 商品管理操作类接口
    /// </summary>
    public interface IShopRepository : IBaseRepository<ShopEntity>
    {
        /// <summary>
        /// 查询首页商品信息
        /// </summary>
        /// <param name="top">显示几条数据</param>
        /// <param name="type">分类描述(1:发展历程,2:最新推荐,3:初心优惠)</param>
        /// <returns></returns>
        Task<IQueryable<ShopHomeInfo>> GetShopHomeInfo(int top, int type);
    }
}