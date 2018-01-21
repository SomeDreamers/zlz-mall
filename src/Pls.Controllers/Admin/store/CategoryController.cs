using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Pls.Utils;

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
        public CategoryController(ApplicationConfigServices _applicationConfigServices) : base(_applicationConfigServices)
        {

        }
    }
}
