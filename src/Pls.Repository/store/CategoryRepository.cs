using Pls.Entity;
using Pls.Entity.entity.store;
using Pls.IRepository.store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Repository.store
{
    /// <summary>
    /// 分类仓储管理
    /// </summary>
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
