using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Pls.Utils;
using Pls.IService.store;
using System.Threading.Tasks;

namespace Pls.Controllers.Admin.store
{
    /// <summary>
    /// 商品评论控制器的实现
    /// </summary>
    [Area("Admin")]
    [Login]
    [AjaxOnly]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ApplicationConfigServices _applicationConfigServices, ICategoryService categoryService) : base(_applicationConfigServices)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// 获取分类数据
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllCategory()
        {
            var categorys = await categoryService.GetCategoryAllInfosAsync();
            return Json(categorys);
        }

        /// <summary>
        /// 获取一级分类数据
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            var categorys = await categoryService.GetCategory1stsAsync();
            return Json(categorys);
        }

        /// <summary>
        /// 获取二级分类数据
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ChildList(long parentId)
        {
            var categorys = await categoryService.GetCategory2rdByParentIdAsync(parentId);
            return Json(categorys);
        }

        /// <summary>
        /// 分类管理首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
