//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:         Pls.Entity/CarouselInfo 
//  创建人:                     Brian     
//  创建时间:                   12/04/2016 14:34:24 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pls.Entity
{
    public class CarouselInfo : PageEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string carousel_titie { get; set; }

        /// <summary>
		/// (默认否:false) 是否禁用(管理员设置)
		/// </summary>
		public int disable { get; set; } = (int)DisableStatus.disable_false;
    }
}
