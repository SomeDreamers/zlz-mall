using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Entity.entity.store
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    public class CategoryEntity
    {
        /// <summary>
        ///  分类表Id-主键
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 父级分类ID
        /// </summary>
        public long parent_id { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public int weight { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool is_del { get; set; }
    }
}
