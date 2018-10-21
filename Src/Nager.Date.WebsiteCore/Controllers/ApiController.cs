using Microsoft.AspNetCore.Mvc;

namespace Nager.Date.WebsiteCore.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
