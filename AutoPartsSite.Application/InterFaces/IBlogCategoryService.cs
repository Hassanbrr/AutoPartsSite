using AutoPartsSite.Application.DTOs;

namespace AutoPartsSite.Application.InterFaces;

public interface IBlogCategoryService
{
    Task<IEnumerable<BlogCategoryDto>> GetAllCategoryAsync();
    Task<BlogCategoryDto> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(BlogCategoryDto categoryDto);

    Task UpdateCategoryAsync(BlogCategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);
}