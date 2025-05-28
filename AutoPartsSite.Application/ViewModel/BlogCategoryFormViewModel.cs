using AutoPartsSite.Application.DTOs;

namespace AutoPartsSite.Application.ViewModel;

public class BlogCategoryFormViewModel
{
    public BlogCategoryDto Category { get; set; }
    public List<BlogCategoryDto> AllCategories { get; set; } // برای DropDown
}