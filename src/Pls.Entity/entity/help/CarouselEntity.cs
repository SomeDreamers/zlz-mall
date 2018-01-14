//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/CarouselEntity 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/11/3 15:05:33
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pls.Entity
{
    /// <summary>
    /// 图片轮播表(Pls_Carousel)
    /// </summary>
    public class CarouselEntity
    {
        /// <summary>
        ///  图片轮播表-主键
        /// </summary>
        public string carousel_id { get; set; } = CommonUtil.CreateGuid();

        /// <summary>
        /// 轮播标题
        /// </summary>
        public string carousel_titie { get; set; }

        /// <summary>
        /// 轮播内容
        /// </summary>
        public string carousel_conent { get; set; }

        /// <summary>
        /// 轮播图片
        /// </summary>
        public string carousel_image { get; set; }

        /// <summary>
        /// 轮播超链接
        /// </summary>
        public string carousel_href { get; set; }

        /// <summary>
        /// 轮播排序
        /// </summary>
        public int carousel_sort { get; set; } = 1;

        /// <summary>
        /// 创建时间(当前时间)
        /// </summary>
        public DateTime createtime { get; set; } = DateTime.Now;

        /// <summary>
        /// (默认否:false) 是否禁用(管理员设置)
        /// </summary>
        public int disable { get; set; } = (int)DisableStatus.disable_false;

        /// <summary>
        ///  可空  禁用原因
        /// </summary>
        public string disabledesc { get; set; }

        /// <summary>
        /// 版本控制(预留字段，后面做并发处理)
        /// </summary>
        [Timestamp]
        public byte[] row_number { get; set; }
    }
}