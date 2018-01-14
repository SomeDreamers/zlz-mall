//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/SourceStatus 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/28 11:19:10
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    /// <summary>
    /// 前后端区分表示(1:前段，2:后端)
    /// </summary>
    public enum SourceStatus
    {
        /// <summary>
        /// 前端
        /// </summary>
        front = 1,

        /// <summary>
        /// 后端
        /// </summary>
        admin = 2

    }
}