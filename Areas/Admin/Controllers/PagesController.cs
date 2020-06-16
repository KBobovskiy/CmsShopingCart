using Microsoft.AspNetCore.Mvc;

namespace CmsShopingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        public string Index()
        {
            return "test string";
        }
    }
}