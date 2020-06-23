using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsShopingCart.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CmsShopingCart.Areas.Admin.Controllers
{
    public class CategiriesController : Controller
    {
        private readonly CmsShopingCartContext context;

        public CategiriesController(CmsShopingCartContext context)
        {
            this.context = context;
        }

        //GET /admin/pages
        public async Task<IActionResult> Index()
        {
            var pagesList = await context.Pages.Select(p => p).ToListAsync();
            return View(pagesList);
        }
    }
}