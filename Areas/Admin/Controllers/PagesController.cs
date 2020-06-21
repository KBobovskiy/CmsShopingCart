using CmsShopingCart.Infrastructure;
using CmsShopingCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        //POST /admin/pages/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Id == page.Id);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Title is already exist!");
                    return View(page);
                }

                context.Pages.Add(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page has been added!";

                return RedirectToAction("Index");
            }

            return View(page);
        }

        //GET /admin/pages/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        //POST /admin/pages/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page is already exist!");
                    return View(page);
                }

                context.Update(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page has been edited!";

                return RedirectToAction("Edit", new { page.Id });
            }

            return View(page);
        }

        //GET /admin/pages/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (page == null)
            {
                TempData["Error"] = "The page does not exist!";
                return NotFound();
            }

            context.Pages.Remove(page);
            await context.SaveChangesAsync();

            TempData["Success"] = "The page has been deleted!";

            return RedirectToAction("Index");
        }

        //POST /admin/pages/reorder
        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            var count = 1;

            foreach (var idItem in id)
            {
                var page = await context.Pages.FirstOrDefaultAsync(x => x.Id == idItem);
                page.Sorting = count;
                context.Update(page);
                await context.SaveChangesAsync();

                count++;
            }

            return Ok();
        }
    }
}