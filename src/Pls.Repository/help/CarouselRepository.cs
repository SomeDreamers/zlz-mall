//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Repository/CarouselRepository 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 16:01:41
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using Pls.IRepository;

namespace Pls.Repository
{
    /// <summary>
    /// 图片轮播 操作类实现
    /// </summary>
    public class CarouselRepository : BaseRepository<CarouselEntity>, ICarouselRepository
    {
        public CarouselRepository(DataContext context) : base(context)
        {
        }
    }
}