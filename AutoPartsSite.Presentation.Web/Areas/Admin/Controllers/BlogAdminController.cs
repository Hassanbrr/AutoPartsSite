using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogAdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IBlogService _blogService;

        private readonly IBlogCategoryService _blogCategoryService;

        public BlogAdminController(
            IBlogService blogService,
            IBlogCategoryService blogCategoryService,
            IWebHostEnvironment webHostEnvironment)
        {
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
            _blogCategoryService = blogCategoryService;
        }


        public async Task<IActionResult> Index()
        {

            var posts = await _blogService.GetAllPostsAsync();
            return View(posts);
        }

        [HttpPost]
        
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllPostsAsync();
            var result = blogs.Select(b => new
            {
                b.Id,
                b.Title,
                b.Summary,
                b.Content,
                b.FeaturedImage,
                CreatedAt = b.PublishDate.ToString("yyyy/MM/dd HH:mm")
            });

            return Json(new { data = result });
        }


        // وقتی روی دکمه کلیک می‌شود
        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            BlogPostDto dto = id == null
                ? new BlogPostDto()
                : await _blogService.GetPostByIdAsync((int)id);
            var categories = await _blogCategoryService.GetAllCategoryAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return PartialView("_UpsertModal", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(BlogPostDto blogDto)
        {
            if (!ModelState.IsValid)
                return PartialView("_UpsertModal", blogDto);

            if (blogDto.Id == 0)
                await _blogService.AddPostAsync(blogDto);
            else
                await _blogService.UpdatePostAsync(blogDto);

            return Json(new { success = true }); ;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImageAdmin(IFormFile upload)
        {
            if (upload == null || upload.Length == 0)
            {
                return Json(new { error = new { message = "فایل معتبر نیست." } });
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await upload.CopyToAsync(stream);
            }

            var imageUrl = Url.Content("~/uploads/" + uniqueFileName); // برای CKEditor

            return Json(new { url = imageUrl });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
         await   _blogService.DeletePostAsync(id);
            // می‌توانید redirect به Index یا برگرداندن JSON برای AJAX انجام دهید
            return RedirectToAction("Index");
        }


    }
}
