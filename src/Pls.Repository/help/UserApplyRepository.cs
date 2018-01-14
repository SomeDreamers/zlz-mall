//=============================================================
//  Copyright (C) 2016-2100
//  CLR版本:                    4.0.30319.42000
//  机器名称:                   BRIAN
//  命名空间名称/文件名:        Pls.Repository/UserApplyRepository 
//  创建人:                     Brian     
//  创建时间:                   12/6/2016 9:01:13 PM
//  网站:                       http://www.chuxinm.com
//==============================================================
using Pls.Entity;
using Pls.IRepository;

namespace Pls.Repository
{
    /// <summary>
    /// 入驻管理操作类实现
    /// </summary>
    public class UserApplyRepository : BaseRepository<UserApplyEntity>, IUserApplyRepository
    {
        public UserApplyRepository(DataContext context) : base(context)
        {

        }
    }
}