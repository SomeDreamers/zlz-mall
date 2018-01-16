using System;
using System.Collections.Generic;
using System.Text;
using Pls.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Pls.Controllers.filter;

namespace Pls.Controllers.Weixin
{
    [Area("Weixin")]
    [CustomOAuth]
    public class HomeController : BaseController
    {
        public HomeController(ApplicationConfigServices _applicationConfigServices) : base(_applicationConfigServices)
        {
        }

        public async Task<IActionResult> Index()
        {
            var request = HttpContext.Request;
            return View();
        }
    }
}
