using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Clint.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
