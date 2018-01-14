//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/DisableStatus 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/28 10:50:56
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    /// <summary>
    /// 禁用状态枚举
    /// </summary>
    public enum DisableStatus
    {
        /// <summary>
        /// 禁用、未激活、不可访问、未解决、未读
        /// </summary>
        disable_true = 1,

        /// <summary>
        /// 启用、激活、可访问、已解决、已读
        /// </summary>
        disable_false = 0
    }
}