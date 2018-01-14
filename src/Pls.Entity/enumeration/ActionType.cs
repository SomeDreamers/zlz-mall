//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/ActionType 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/28 11:40:10
//  网站：				  		http://www.chuxinm.com
//==============================================================

namespace Pls.Entity
{
    /// <summary>
    /// 菜单类型来源(默认2) 1：前台页面  2，后台左侧导航  3，普通按钮
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// 前台页面菜单
        /// </summary>
        front = 1,

        /// <summary>
        /// 后台左侧导航按钮
        /// </summary>
        adminleft = 2,

        /// <summary>
        /// 普通按钮
        /// </summary>
        general = 3,

        /// <summary>
        /// 后台查询
        /// </summary>
        adminselect = 4,

        /// <summary>
        /// 普通按钮-不显示
        /// </summary>
        general_noshow = 5
    }
}