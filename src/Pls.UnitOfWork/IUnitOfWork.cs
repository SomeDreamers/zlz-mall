//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.UnitOfWork/IUnitOfWork 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using System.Threading.Tasks;

namespace Pls.UnitOfWork
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 统一提交(同步请求)
        /// </summary>
        /// <returns></returns>
        bool SaveCommit();

        /// <summary>
        /// 统一提交(异步请求)
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveCommitAsync();
    }
}