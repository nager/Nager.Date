using Microsoft.AspNetCore.Mvc;

namespace Nager.Date.WebsiteCore.Controllers
{
    public class SitemapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
