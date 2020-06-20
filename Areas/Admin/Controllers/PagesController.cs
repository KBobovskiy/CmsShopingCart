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

        //GET /admin/pages
        public async Task<IActionResult> Index()
        {
            var pagesList = await context.Pages.Select(p => p).ToListAsync();
            return View(pagesList);
        }

        //GET /admin/pages/id
        public async Task<IActionResult> Details(int id)
        {
            var page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        //GET /admin/pages/create
        public IActionResult Create() => View();
    }
}