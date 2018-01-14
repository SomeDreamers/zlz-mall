//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ShopCommentView 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/12/1 10:16:14
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Collections.Generic;

namespace Pls.Entity
{
    /// <summary>
    /// 下商品详情展示信息
    /// </summary>
    public class ShopCommentView : ShopCommentInfo
    {
        /// <summary>
        /// 商品图片地址
        /// </summary>
        public List<string> image_address { get; set; } = new List<string>();
    }
}