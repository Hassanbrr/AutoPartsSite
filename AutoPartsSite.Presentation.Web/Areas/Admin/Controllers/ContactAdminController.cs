using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    public class ContactAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
