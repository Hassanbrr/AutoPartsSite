using AutoPartsSite.Application.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogAdminController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogAdminController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _blogService.GetAllPostsAsync();

            return View();
        }
    }
}
