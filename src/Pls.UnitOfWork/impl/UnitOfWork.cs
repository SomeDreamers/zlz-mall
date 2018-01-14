//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                	4.0.30319.42000
//  机器名称:                   KENCERY-PC
//  命名空间名称/文件名:        Pls.UnitOfWork/UnitOfWork 
//  创建人:			   	  		kencery     
//  创建时间:     		  		2016/9/19 20:03:37
//  网站：				  		http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using System;
using System.Threading.Tasks;

namespace Pls.UnitOfWork
{
    /// <summary>
    /// 工作单元实现
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        private DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public bool SaveCommit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveCommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}