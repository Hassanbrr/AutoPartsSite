using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    public class BlogAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
