using CmsShopingCart.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CmsShopingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly CmsShopingCartContext context;

        public PagesController(CmsShopingCartContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pagesList = await context.Pages.Select(p => p).ToListAsync();
            return View(pagesList);
        }
    }
}