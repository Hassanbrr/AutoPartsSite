using AutoMapper;
using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Repository.Modules.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Clint.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _blogService.GetAllPostsAsync();
            return View(posts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }


}
