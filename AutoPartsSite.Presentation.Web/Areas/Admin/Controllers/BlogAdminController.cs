using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogAdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IBlogService _blogService;

        public BlogAdminController(IBlogService blogService, IWebHostEnvironment webHostEnvironment)
        {
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {

            var posts = await _blogService.GetAllPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _blogService.GetPostByIdAsync(id);
            return Json(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(BlogPostDto blogDto)
        {
            if (blogDto.Id == 0 || blogDto.Id == null)
            {
                await _blogService.AddPostAsync(blogDto);
            }
            else
            {
                await _blogService.UpdatePostAsync(blogDto);
            }

            return Ok();
        }
    }
}
