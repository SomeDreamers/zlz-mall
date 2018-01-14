//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	ProgrammersLiveShow/HomeShopViewComponent 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/28 15:26:49
//  网站：				  		http://www.chuxinm.com
//==============================================================

using Microsoft.AspNetCore.Mvc;
using Pls.IService;
using System.Threading.Tasks;

namespace ProgrammersLiveShow
{
    /// <summary>
    /// 初心首页信息展示读取数据库的实现,提供给首页使用（）
    /// </summary>
    public class HomeShopViewComponent : ViewComponent
    {
        public IShopService shopService { get; private set; }
        public HomeShopViewComponent(IShopService _shopService)
        {
            shopService = _shopService;
        }

        /// <summary>
        /// 根据用户Id和路径查询按钮集合并且返回
        /// </summary>
        /// <param name="top">显示几条数据</param>
        /// <param name="type">分类描述(1:发展历程,2:最新推荐,3:初心优惠)</param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(int top, int type = 1)
        {
            var result = await shopService.GetShopHomeInfo(top, type);
            return View("HomeShop", result);
        }
    }
}