using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Presentation.Web.Infrastructure.Helps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsSite.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryAdminController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoryAdminController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        // نمایش لیست دسته‌بندی‌ها
        public async Task<IActionResult> Index()
        {
            var categories = await _blogCategoryService.GetAllCategoryAsync();
            return View(categories);
        }

        // GET: بارگذاری مدال برای افزودن/ویرایش دسته
        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            BlogCategoryDto dto = id == null
                ? new BlogCategoryDto()       // افزودن دسته جدید
                : await _blogCategoryService.GetCategoryByIdAsync((int)id); // ویرایش دسته موجود

            // دریافت لیست کلی دسته‌ها برای انتخاب والد
            var allCategories = await _blogCategoryService.GetAllCategoryAsync();
            if (id != null)
            {
                // جلوگیری از انتخاب خود دسته به عنوان والد
                allCategories = allCategories.Where(c => c.Id != id).ToList();
            }
            ViewBag.ParentCategories = new SelectList(allCategories, "Id", "Name", dto.ParentCategoryId);

            return PartialView("_UpsertModal", dto);
        }
        // POST: ذخیره تغییرات (افزودن یا ویرایش)
        [HttpPost]
        public async Task<IActionResult> Upsert(BlogCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_UpsertModal", categoryDto); // نمایش مجدد فرم با خطاها
            }

            if (categoryDto.Id == 0)
                await _blogCategoryService.AddCategoryAsync(categoryDto);
            else
                await _blogCategoryService.UpdateCategoryAsync(categoryDto);

            return Json(new { success = true }); // ارسال پاسخ موفقیت‌آمیز
        }

        // حذف دسته‌بندی
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogCategoryService.DeleteCategoryAsync(id);
            return Json(new { success = true });
        }


    }

}
