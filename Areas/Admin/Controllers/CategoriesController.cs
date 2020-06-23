using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsShopingCart.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CmsShopingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly CmsShopingCartContext context;

        public CategoriesController(CmsShopingCartContext context)
        {
            this.context = context;
        }

        //GET /admin/categories
        public async Task<IActionResult> Index()
        {
            return View(await context.Categories.OrderBy(c => c.Sorting).ToListAsync());
        }
    }
}