using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Domain;
using AutoPartsSite.Repository.Modules.Base.Interfaces;

namespace AutoPartsSite.Application.Services;

public class BlogCategoryService : IBlogCategoryService
{

    private readonly IUnitOffWork _unitOffWork;
    private readonly IMapper _mapper;

    public BlogCategoryService(IUnitOffWork unitOffWork, IMapper mapper)
    {
        _unitOffWork = unitOffWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BlogCategoryDto>> GetAllCategoryAsync()
    {
        var categories = await _unitOffWork.BlogCategory.GetAllAsync("ParentCategory");
        return _mapper.Map<IEnumerable<BlogCategoryDto>>(categories);
    }

    public async Task<BlogCategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOffWork.BlogCategory.GetByIdAsync(id);
        return category == null ? null : _mapper.Map<BlogCategoryDto>(category);
    }

    public async Task AddCategoryAsync(BlogCategoryDto categoryDto)
    {

        var category = _mapper.Map<BlogCategory>(categoryDto);
      

        await _unitOffWork.BlogCategory.AddAsync(category);
        await _unitOffWork.SaveChangesAsync();

    }

    public async Task UpdateCategoryAsync(BlogCategoryDto categoryDto)
    {
        var category = await _unitOffWork.BlogCategory.GetByIdAsync(categoryDto.Id);
        if (category == null) return;
        _mapper.Map(categoryDto, category);
        _unitOffWork.BlogCategory.Update(category);
        await _unitOffWork.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _unitOffWork.BlogCategory.GetCategoryWithChildrenAndPostsAsync(id);

        if (category == null) return;

        var hasChildren = category.ChildCategories.Any();
        var hasPosts = category.BlogPosts.Any();

        if (hasChildren || hasPosts)
            throw new InvalidOperationException("امکان حذف دسته‌ای که دارای زیرمجموعه یا پست است وجود ندارد.");

        _unitOffWork.BlogCategory.Remove(category);
        await _unitOffWork.SaveChangesAsync();
    }

}