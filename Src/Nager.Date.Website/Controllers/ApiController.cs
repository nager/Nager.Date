using Microsoft.AspNetCore.Mvc;

namespace Nager.Date.Website.Controllers
{
    /// <summary>
    /// Api
    /// </summary>
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
