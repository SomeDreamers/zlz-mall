using Pls.Entity.entity.store;
using Pls.Entity.response.store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pls.IService.store
{
    /// <summary>
    /// 分类管理接口
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// 根据ID获取分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryEntity> GetCategoryByIdAsync(long id);

        /// <summary>
        /// 获取所有分类信息
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryAllInfo>> GetCategoryAllInfosAsync();

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryEntity>> GetCategory1stsAsync();

        /// <summary>
        /// 根据父级分类ID获取二级分类集合
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<CategoryEntity>> GetCategory2rdByParentIdAsync(long parentId);
    }
}
