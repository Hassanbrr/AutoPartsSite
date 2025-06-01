using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsSite.Presentation.Web.Areas.Client.ViewComponents
{
    public class BlogPostViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogPostViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _blogService.GetAllPostsAsync();
            return View(posts);
        }
    }
}
