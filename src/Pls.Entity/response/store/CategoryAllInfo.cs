using Pls.Entity.entity.store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Entity.response.store
{
    /// <summary>
    /// 所有分类信息
    /// </summary>
    public class CategoryAllInfo
    {
        /// <summary>
        /// 分类
        /// </summary>
        public CategoryEntity Category { get; set; }

        /// <summary>
        /// 子分类信息
        /// </summary>
        public List<CategoryEntity> Childs { get; set; } = new List<CategoryEntity>();
    }
}
