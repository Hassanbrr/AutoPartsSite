using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryAdminController : Controller
    {
        private readonly IBlogCategoryService _categoryService;

        public BlogCategoryAdminController(IBlogCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            BlogCategoryDto dto = id == null
                ? new BlogCategoryDto()
                : await _categoryService.GetCategoryByIdAsync((int)id);

            var allCategories = (await _categoryService.GetAllCategoryAsync()).ToList();

            ViewBag.ParentCategories = BlogCategoryTreeHelper.BuildCategoryTree(allCategories, dto.ParentCategoryId, dto.Id);

            return PartialView("_UpsertModal", dto);
        }


        [HttpPost]
        public async Task<IActionResult> Upsert(BlogCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                var allCategories = (await _categoryService.GetAllCategoryAsync())
                                    .Where(c => c.Id != dto.Id).ToList();
                ViewBag.ParentCategories = BlogCategoryTreeHelper.BuildCategoryTree(allCategories, dto.ParentCategoryId, dto.Id);

                return PartialView("_UpsertModal", dto);
            }

            if (dto.Id == 0)
                await _categoryService.AddCategoryAsync(dto);
            else
                await _categoryService.UpdateCategoryAsync(dto);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
