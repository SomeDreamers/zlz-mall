using Pls.Entity.entity.store;
using Pls.Entity.response.store;
using Pls.IRepository.store;
using Pls.IService.store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pls.Service.store
{
    /// <summary>
    /// 分类管理service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// 根据ID获取分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryEntity> GetCategoryByIdAsync(long id)
        {
            var category = await categoryRepository.GetAsync(c => c.id == id);
            return category;
        }

        /// <summary>
        /// 获取所有分类信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryAllInfo>> GetCategoryAllInfosAsync()
        {
            List<CategoryAllInfo> categoryInfos = new List<CategoryAllInfo>();
            var categorys = await GetCategory1stsAsync();
            foreach (var item in categorys)
            {
                categoryInfos.Add(new CategoryAllInfo
                {
                    Category = item,
                    Childs = await GetCategory2rdByParentIdAsync(item.parent_id)
                });
            }
            return categoryInfos;
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryEntity>> GetCategory1stsAsync()
        {
            var categorys = (from n in await categoryRepository.GetAllAsync(c => c.parent_id == 0)
                             orderby n.type ascending
                             orderby n.weight descending
                             select new CategoryEntity()
                             ).ToList();
            return categorys;
        }

        /// <summary>
        /// 根据父级分类ID获取二级分类集合
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<CategoryEntity>> GetCategory2rdByParentIdAsync(long parentId)
        {
            var categorys = (from n in await categoryRepository.GetAllAsync(c => c.parent_id == parentId)
                             orderby n.weight descending
                             select new CategoryEntity()
                             ).ToList();
            return categorys;
        }
    }
}
