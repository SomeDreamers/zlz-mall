//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/MenuActionInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/10/12 11:07:33
//  网站：				  		http://www.chuxinm.com
//==============================================================

using System.Collections.Generic;

namespace Pls.Entity
{
    /// <summary>
    /// 返回菜单信息
    /// </summary>
    public class MenuActionInfo
    {
        /// <summary>
        /// 主键-GUID()
        /// </summary>
        public string action_id { get; set; }

        /// <summary>
        /// 页面或者按钮名称
        /// </summary>
        public string action_name { get; set; }

        /// <summary>
        /// 可空  页面或者按钮请求路径
        /// </summary>
        public string action_url { get; set; }

        /// <summary>
        /// 可空  页面，按钮图标
        /// </summary>
        public string action_icon { get; set; }

        /// <summary>
        /// 非空，是否为新功能 默认为新 true
        /// </summary>
        public bool action_newaction { get; set; }

        /// <summary>
        /// 菜单详情
        /// </summary>
        public List<MenuActionInfo> menuActionInfo { get; set; }
    }
}