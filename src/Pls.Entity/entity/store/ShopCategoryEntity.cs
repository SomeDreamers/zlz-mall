using System;
using System.Collections.Generic;
using System.Text;

namespace Pls.Entity.entity.store
{
    /// <summary>
    /// 商品分类关系实体
    /// </summary>
    public class ShopCategoryEntity
    {
        /// <summary>
        ///  商品分类关系表Id-主键
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public long shop_id { get; set; }

        /// <summary>
        /// 一级分类ID
        /// </summary>
        public long category1st_id { get; set; }

        /// <summary>
        /// 二级分类ID
        /// </summary>
        public long category2rd_id { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public int weight { get; set; }
    }
}
