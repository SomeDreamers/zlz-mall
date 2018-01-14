//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:               	KENCERY-PC
//  命名空间名称/文件名:    	Pls.Entity/DepartmentInfo 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/20 14:58:21
//  网站：				  		http://www.chuxinm.com
//==============================================================
namespace Pls.Entity
{
    /// <summary>
    /// 部门查询实体
    /// </summary>
    public class DepartmentInfo : PageEntity
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 部门状态(是否禁用)
        /// </summary>
        public int status { get; set; }
    }
}